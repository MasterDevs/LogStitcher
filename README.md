# LogStitcher [![Build status](https://ci.appveyor.com/api/projects/status/nwhu2wwku7e0aitp/branch/master?svg=true)](https://ci.appveyor.com/project/jquintus/logstitcher/branch/master) [![Chocolatey](https://img.shields.io/chocolatey/dt/scriptcs.svg?style=flat-square)](https://chocolatey.org/packages/LogStitcher.portable) [![Chocolatey](https://img.shields.io/chocolatey/v/git.svg?style=flat-square)](https://chocolatey.org/packages/LogStitcher.portable)


Stitches multiple logs together, interweaving entries to make them chronological

# Installation
TidyJson can be installed with [Chocolatey](https://chocolatey.org/)

    choco install logstitcher.portable
    
    
# Usage
    Usage: logstitcher [File1] [File2] ...

Example 1:  Stitch two files and print the result to stdin

    logstitcher c:\logs\logFile1 c:\logs\logFile2
    
Example 2:  Stitch all the .txt files in a directory and save the result to a file
    
    logstitcher c:\logs\*.txt > c:\logs\stitched.log
    
Example 3:  Stitching with wild cards across multiple directories
    
    logstitcher c:\logs\directoryA\*.txt c:\logs\directoryB\*.txt 

# Credits

LogStitcher uses the following projects:

* [MasterDevs.ChocolateyCoolWhip](https://github.com/MasterDevs/ChocolateyCoolWhip) to build and deploy to Chocolatey

