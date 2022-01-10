# OpDrop

OpDrop, short for Operation Drop, is an extremely simple solution for running some code (whether it's a block of code or a method), and needing the ability to cancel that code execution.

I came across a need for something like this when working with Background tasks in .NET Core. I setup a Ui to be able to see the current status of each job. So, if a job was hung up for some reason or another, I needed a way to be able to cancel the code execution. This provides a very easy solution to do just that.

