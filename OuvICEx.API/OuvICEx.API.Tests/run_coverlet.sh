#!/bin/sh
dotnet build
coverlet ./bin/Debug/net6.0/OuvICEx.API.Tests.dll --target "dotnet" --targetargs "test --no-build"