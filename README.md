# Promise Group Recruitment Task

## Opis zadania
Aplikacja konsolowa umożliwiająca procesowanie zamówienia.

## Statusy zamówienia
Zamówienie może posiadać jeden z sześciu statusów:
1. **Nowe**
2. **W magazynie**
3. **W wysyłce**
4. **Zwrócono do klienta**
5. **Błąd**
6. **Zamknięte**

## Funkcjonalność aplikacji
Aplikacja powinna umożliwiać wykonanie następujących operacji:
1. **Utworzenie przykładowego zamówienia**
2. **Przekazanie zamówienia do magazynu**
3. **Przekazanie zamówienia do wysyłki**
4. **Przegląd zamówień**
5. **Wyjście**

## Struktura zamówienia
Zamówienie składa się z następujących właściwości:
- **Kwota zamówienia**
- **Nazwa produktu**
- **Typ klienta** (firma, osoba fizyczna)
- **Adres dostawy**
- **Sposób płatności** (karta, gotówka przy odbiorze)

## Warunki biznesowe
1. Zamówienia na kwotę **nie mniejszą niż 2500 PLN** z płatnością **gotówką przy odbiorze** powinny zostać **zwrócone do klienta** przy próbie przekazania do magazynu.
2. Zamówienia przekazane do wysyłki powinny **po maksymalnie 5 sekundach** zmienić status na **"wysłane"**.
3. Zamówienia **bez adresu dostawy** powinny kończyć się statusem **błąd**.



