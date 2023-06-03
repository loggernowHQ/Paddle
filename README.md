
# Paddle
This package provides abstraction to paddle webhooks and apis.



## Features

This package exposes below methods to interact with paddle

- VerifySignature
```
Paddle p=new Paddle(your_public_key_string);
bool result=p.VerifySignature(Httprequest recived);
```
```
