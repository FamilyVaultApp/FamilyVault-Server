FROM mcr.microsoft.com/dotnet/aspnet:8.0

ADD build_output /familyvault

EXPOSE 8080/tcp

CMD [ "dotnet", "familyvault/FamilyVaultServer.dll" ]