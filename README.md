# OpDrop

OpDrop, short for Operation Drop, is an extremely simple solution for running some code (whether it's a block of code or a method), and needing the ability to cancel that code execution.

I came across a need for something like this when working with Background tasks in .NET Core. If a job got hung up for some reason or another, due to poor performance, errors, or endless looping or whatever, I needed a way to be able to cancel the code execution. This provides a very easy solution to do that.

Essentially, the code is running in it's own task, and a CancellationTokenSource is assigned to it. Which can then be canceled at any point from anywhere in your code.

# Usage

All you have to do is call the Run method on the Worker class inside the OpDrop namespace.
````
OpDrop.Worker.Run
````
The Run method takes 2 required arguments. The first is a custom identifier (string) so that you can reference it later and either cancel the code and/or retrieve any possible errors.

Below is an example using a block of code

![opdrop1](https://user-images.githubusercontent.com/10837928/148834104-62935dae-16c5-4ab0-9ed9-6ad1ed2353f8.PNG)

The next example is passing a method through.

![opdrop2](https://user-images.githubusercontent.com/10837928/148834990-c4008693-5589-4a1f-a06a-b80f059b2ded.PNG)

To cancel the code execution simply call the Cancel method on the Worker class. You will need to provide the identifier used when running the code.
````
OpDrop.Worker.Cancel
````
![opdrop3](https://user-images.githubusercontent.com/10837928/148835429-f77c2c7d-3193-4909-8dc5-70bd6f95e9e5.PNG)
