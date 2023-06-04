
# Paddle
This package provides abstraction to paddle webhooks and apis.



## Features

This package exposes below methods to interact with paddle

- VerifySignature
This method takes in HttpRequest and returns if paddle webhook is valid or not
```
Paddle p=new Paddle(your_public_key_string);
bool result=p.VerifySignature(HttpRequest recived);
```

- ParsePaddleWebhook
This method takes in potional parameter of paddle HttpRequest if it wad not already provided while verifying webhook signature earlier and parses the data and return PaddleWebhook with initialised filds.
```
Paddle p=new Paddle(your_public_key_string);
bool result=p.ParsePaddleWebhook(HttpRequest recived);
```
This also throws error ```HttpRequest not initialised``` if you dont pass in ```HttpRequest``` while calling this function and you have not provided ```HttpRequest``` before.

