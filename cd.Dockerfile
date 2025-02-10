FROM mcr.microsoft.com/dotnet/aspnet:8.0

ADD build_output /familyvault

EXPOSE 8080/tcp

ENV ASPNETCORE_ENVIRONMENT="Development"
WORKDIR "/familyvault"

CMD [ "dotnet", "FamilyVaultServer.dll" ]