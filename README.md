# Microservices
.Net 5.0 İle inşa ettiğim microservice proje yapısı
![microservice proje yapısı](https://user-images.githubusercontent.com/89848535/207954245-e088270f-a98a-4a94-917f-c645ac85e2a9.png)

Microservices :

Catalog Microservice

Kurslarımız ile ilgili bilgilerin tutulmasından ve sunulmasından sorumlu olacak mikroservice

    MongoDb (Veritabanı)

    One-To-Many/One-To-One ilişki

    MongoDb

Basket Microservice

Sepet işlemlerinden sorumlu olacak mikroservice

    RedisDB(Veritabanı)

Discount Microservice

Kullanıcıya tanımlanacak indirim kuponlarından sorumlu olacak mikroservice

    PostgreSQL(Veritabanı)

Order Microservice

Sipariş işlemlerinden sorumlu olacak mikroservice

Bu mikroservisimizde Domain Driven Design yaklaşımını kullanarak geliştirildi

Bu mikroservisimizde CQRS tasarım kalıbını uygulamak için MediatR kütüphanesini kullanıldı.

    Sql Server(Veritabanı)

    Domain Driven Design

    CQRS (MediatR Libarary)

FakePayment Microservice

Ödeme işlemlerinden sorumlu olacak mikroservice

IdentityServer Microservice

    Sql Server(Veritabanı)

Kullanıcı dataların tutulmasından,token ve refreshtoken üretilmesinden sorumlu olacak mikroservice

PhotoStock Microservice

Kurs fotograflarının tutulmasından ve sunulmasından sorumlu olacak mikroservice

API Gateway

    Ocelot Library

Message Broker

    Mesaj kuyruk sistemi olarak RabbitMQ kullanıldı

    RabbitMQ ile haberleşmek için MassTransit kütüphanesini kullanıldı

    RabbitMQ (MassTransit Library)

Identity Server

    Token / RefreshToken üretmek

    Access Token ile microservice'lerimizi korumak

    OAuth 2.0 / OpenID Connect protokollerine uygun yapı inşa etmek

Asp.Net Core MVC Microservice

Microservice'lerden almış olduğu dataları kullanıcıya gösterecek ve kullanıcı ile etkileşime geçmekten sorumlu olacak UI mikroservice
