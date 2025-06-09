# FamilyVault Server

## Opis Projektu

FamilyVault Server to część serwerowa solucji FamilyVault. Integruje się z usługą PrivMx Bridge, wykorzystując ją do operacji na danych, zarządzania użytkownikami i kontekstami (grupami rodzinnymi).

Głównym celem projektu jest umożliwienie tworzenia bezpiecznych przestrzeni dla grup rodzinnych, gdzie członkowie mogą współdzielić informacje i zasoby z różnymi poziomami dostępu.

## Główne Funkcjonalności

*   **Zarządzanie Grupami Rodzinnymi:**
    *   Tworzenie nowych grup rodzinnych (kontekstów w PrivMx).
    *   Zmiana nazwy istniejących grup.
    *   Pobieranie nazwy grupy.
*   **Zarządzanie Członkami Grup:**
    *   Dodawanie nowych członków do grup z określonymi rolami (Opiekun, Członek, Gość).
    *   Listowanie członków danej grupy.
    *   Pobieranie informacji o konkretnym członku grupy (na podstawie ID użytkownika lub klucza publicznego).
    *   Zmiana roli (poziomu uprawnień) członka grupy.
    *   Usuwanie członków z grupy.
*   **Mechanizm Dołączania (Join Status):**
    *   Generowanie unikalnych tokenów do śledzenia procesu dołączania nowego członka.
    *   Aktualizacja statusu procesu dołączania (np. zainicjowany, oczekujący, sukces, błąd).
    *   Pobieranie aktualnego statusu na podstawie tokenu.
    *   Usuwanie tokenów statusu.
*   **Konfiguracja serwera:**
    *   Udostępnianie ID solucji PrivMx.
    *   Udostępnianie adresu URL PrivMx Bridge.

## Uruchomienie

Najprostszym i zalecanym przez nas sposobem uruchomienia serwera FamilyVault jest obraz Dockerowy.

Przed wykorzystaniem tej metody musisz zapewnić działające instancje serwera PrivMX oraz MongoDB.
Więcej informacji znajdziesz [tutaj](https://github.com/simplito/privmx-bridge-docker). 

Obraz FamilyVaultServer możesz pobrać wykorzystując następujące polecenie:
```bash
docker pull ghcr.io/familyvaultapp/familyvaultserver:latest
```

Skonfigurować skonteneryzowany serwer FamilyVault możesz za pomocą zmiennych środowiskowych.
Uruchomienie serwera z przykładową konfiguracją:
```
docker run 
    -p 8080:8080 
    -e PrivMx__Url="https://192.168.0.2:9111" 
    -e PrivMx__ApiKeyId="ecf27cdb0d06919fd9c626d81382fc03" 
    -e PrivMx__ApiKeySecret="8094267e11feb9733543783f393f3b46" 
    ghcr.io/familyvaultapp/familyvaultserver:latest
```
#### Opis przykładowej konfiguracji

- _PrivMx__Url_ – adres URL serwera PrivMX, z którym ma się komunikować FamilyVault. Pamiętaj, że zostanie on przesłany do hostów, dlatego musi być dla nich też dostępny!

- _PrivMx__ApiKeyId_ – identyfikator klucza API wygenerowany przez PrivMx Bridge.

- _PrivMx__ApiKeySecret_ – tajny klucz wygenerowany przez PrivMx Bridge.

## Technologie

*   **Backend:** ASP.NET Core 8.0
*   **Szyfrowanie / przechowanie danych:** PrivMx Bridge
*   **Konteneryzacja:** Docker, Docker Compose
*   **CI/CD:** GitHub Actions

## Konfiguracja

Konfiguracja serwera znajduje się w plikach `appsettings.json` oraz `appsettings.Development.json` (dla środowiska deweloperskiego). Kluczowe ustawienia dotyczą połączenia z PrivMx Bridge:

*   `PrivMx:Url`: Adres URL, pod którym uruchomiony jest PrivMx Bridge. Pamiętaj, że zostanie on przesłany do hostów, dlatego musi być dla nich też dostępny!
*   `PrivMx:ApiKeyId`: ID klucza API do PrivMx Bridge.
*   `PrivMx:ApiKeySecret`: Sekret klucza API do PrivMx Bridge.
*   `PrivMx:SolutionName`: Nazwa solucji w PrivMx.

Serwer automatycznie przechowuje identyfikator solucji PrivMx w pliku `config/solution` w katalogu roboczym serwera (generowanym przy pierwszym uruchomieniu, jeśli plik nie istnieje).

## API Endpoints

Główne grupy endpointów API:

*   `/FamilyGroup/*`: Operacje związane z grupami rodzinnymi i ich członkami.
*   `/JoinStatus/*`: Operacje związane z procesem dołączania nowych członków.
*   `/ApplicationConfig/*`: Endpointy konfiguracyjne aplikacji.
*   `/Ping`: Prosty endpoint do sprawdzania, czy usługa działa (zwraca "Pong").

Szczegółowa dokumentacja endpointów jest dostępna poprzez Swagger UI po uruchomieniu backendu w trybie deweloperskim.

## CI/CD

Projekt wykorzystuje GitHub Actions do automatyzacji procesów CI (Continuous Integration) i CD (Continuous Deployment).

*   **CI (`.github/workflows/ci.yml`):**
    *   Uruchamiany przy każdym pull requeście do `main`.
    *   Buduje projekt w celu weryfikacji poprawności kodu.
*   **CD (`.github/workflows/cd.yml`):**
    *   Uruchamiany przy każdym pushu do `main`.
    *   Buduje projekt .NET.
    *   Tworzy nowy obraz Docker dla serwera `familyvault/server`.
    *   Restartuje stos aplikacji FamilyVault na serwerze docelowym przy użyciu `docker-compose`.

Pliki konfiguracyjne Docker znajdują się w głównym katalogu projektu:
*   [`cd.Dockerfile`](cd.Dockerfile): Definiuje sposób budowania obrazu Docker dla serwera.
*   [`docker-compose.yaml`](docker-compose.yaml): Definiuje usługi potrzebne do uruchomienia pełnego środowiska (serwer, baza danych MongoDB, PrivMx Bridge).

