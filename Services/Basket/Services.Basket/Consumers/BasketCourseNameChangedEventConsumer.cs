using MassTransit;
using Services.Basket.Dtos;
using Services.Basket.Services;
using Shared.Messages;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.Basket.Consumers
{
    public class BasketCourseNameChangedEventConsumer : IConsumer<CourseNameChangedEvent>
    {
        private readonly RedisService _redisService;

        public BasketCourseNameChangedEventConsumer(RedisService redisService)
        {
            _redisService = redisService;
        }
        public async Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            var keys = _redisService.GetKeys();
            if (keys != null)
            {
                foreach (var key in keys)
                {
                    var basket = await _redisService.GetDatabase().StringGetAsync(key);
                    var basketDto = JsonSerializer.Deserialize<BasketDto>(basket);

                    basketDto.basketItems.ForEach(x =>
                    {
                        x.CourseName = x.CourseId == context.Message.CourseId ? context.Message.UpdateName : x.CourseName;
                    });

                    await _redisService.GetDatabase().StringSetAsync(key, JsonSerializer.Serialize(basketDto));
                }
            } 
        }
    }
}