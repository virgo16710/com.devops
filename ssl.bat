@echo off
cd /d "%~dp0"
mkdir ssl
cd ssl
openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout ssl.key -out ssl.crt -subj "/CN=localhost"
pause
