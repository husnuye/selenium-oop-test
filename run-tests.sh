#!/bin/bash

echo "🧹 Temizleniyor..."
pkill -f chromedriver
pkill -f "Google Chrome"

echo "🔧 Build başlatılıyor..."
dotnet clean
dotnet build

echo "🚀 Testler başlatılıyor..."
dotnet test
