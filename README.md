# OpDrop

OpDrop, short for Operation Drop, is an extremely simple solution for running some code (whether it's a block of code or a method), and needing the ability to cancel that code execution.

I came across a need for something like this when working with Background tasks in .NET Core. If a job got hung up for some reason or another, due to poor performance, errors, or endless looping or whatever, I needed a way to be able to cancel the code execution. This provides a very easy solution to do that.

Essentially, the code is running in it's own task, and a CancellationTokenSource is assigned to it. Which can then be canceled at any point.

# Usage

All you have to do is call the Run method on the Worker class inside the OpDrop namespace.
````
OpDrop.Worker.Run
````

![opdrop1](https://user-images.githubusercontent.com/10837928/148834104-62935dae-16c5-4ab0-9ed9-6ad1ed2353f8.PNG)


