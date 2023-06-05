![Logo](https://raw.githubusercontent.com/loggernowHQ/Paddle/fb15486273e023ce6f1627a2be3ea9c3da0c9db8/Documentation/Images/loggernowMsHeader.png)

# Paddle
This package is **under development** and functionality is being added as needed during developement of my side project  [loggernow.com](http://loggernow.com) which aims to provide easy monitoring and searching of logs.

This project aims to provides sdk to interact with paddle webhooks and apis.


## License

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)

## Installation

Install c# Paddle Sdk with nuget

```bash
dotnet add package Paddle --version 0.0.1.31-alpha
```

## Features

This package exposes below methods to interact with paddle

- Initialize Paddle with logging and without logging
```
Paddle p=new Paddle(paddlePublicKeyString);  //without logging enabled
Paddle p=new Paddle(paddlePublicKeyString,ILogger);  //with logging enabled
```

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
PaddleWebhook parsedObj=p.ParsePaddleWebhook(HttpRequest recived); //incase the HttpRequest was not provided earlier
	or
PaddleWebhook parsedObj=p.ParsePaddleWebhook(); //incase the HttpRequest was  provided earlier
```
This also throws error ```HttpRequest not initialised``` if you dont pass in `HttpRequest` while calling this function and you have not provided `HttpRequest` before.


## Authors

- [@OutOfBoundCats](https://github.com/OutOfBoundCats)

## Feedback

If you have any feedback, please reach out to us at raj.patil@loggernow.com

## Contributing

Contributions are always welcome!
Feel free to make pull request.
