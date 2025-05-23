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

## Technologie

*   **Backend:** ASP.NET Core 8.0
*   **Szyfrowanie / przechowanie danych:** PrivMx Bridge
*   **Konteneryzacja:** Docker, Docker Compose
*   **CI/CD:** GitHub Actions

## Konfiguracja

Konfiguracja serwera znajduje się w plikach `appsettings.json` oraz `appsettings.Development.json` (dla środowiska deweloperskiego). Kluczowe ustawienia dotyczą połączenia z PrivMx Bridge:

*   `PrivMx:Url`: Adres URL na którym jest uruchomiony PrivMx Bridge.
*   `PrivMx:ApiKeyId`: ID klucza API do PrivMx Bridge.
*   `PrivMx:ApiKeySecret`: Sekret klucza API do PrivMx Bridge.
*   `PrivMx:SolutionName`: Nazwa solucji w PrivMx.

Serwer automatycznie przechowuje identyfikator solucji PrivMx w pliku `config/solution` w katalogu roboczym serwera (generowanym przy pierwszym uruchomieniu, jeśli plik nie istnieje).

## Uruchomienie

### Wymagania

*   .NET SDK 8.0
*   Docker i Docker Compose

### Kroki

1.  **Uruchomienie zależności (MongoDB, PrivMx Bridge):**
    W głównym katalogu projektu wykonaj polecenie:
    ```sh
    docker-compose up -d mongodb privmx-bridge
    ```
    Poczekaj, aż usługi zostaną uruchomione (możesz sprawdzić logi za pomocą `docker-compose logs -f`).

2.  **Uruchomienie serwera FamilyVault:**
    *   **Z Visual Studio:** Otwórz plik solucji [`FamilyVaultServer.sln`](FamilyVaultServer.sln) i uruchom projekt (np. używając profilu `http` zdefiniowanego w [`launchSettings.json`](FamilyVaultServer/Properties/launchSettings.json)).
    *   **Z linii poleceń:** Przejdź do katalogu `FamilyVaultServer/` i wykonaj:
        ```sh
        dotnet run
        ```

Część serwerowa domyślnie uruchomi się pod adresem `http://localhost:5024`. Dokumentacja API Swagger będzie dostępna pod adresem `http://localhost:5024/swagger` (w środowisku deweloperskim).

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

