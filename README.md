# Tensor 3D console app

Tensor típus
A feladat lényege egy 3D-s Tensornak (3D-s mátrix) a megvalósítása, bemutatása, tesztelése.

Tömb
Az osztály képes egy elméletben 3D-s mátrixot, egydimenziós tömbben tárolni. Ezt a tömböt manipulálva vagyunk képesek a Tensort feltölteni, értékeit átírni, átméretezni, akár 2D-s mátrixok sokaságaként vizualizálni.

Típus-műveletek

1. Létrehozás
Tensor létrehozása, X, Y és Z méreteinek a megadásával.

2. Elem átírása
A kiválasztott Tensor x, y és z koordinátájának a megadásával kiválasztunk egy elemet, majd az értékét felülírjuk a megadott értékkel.

3. Elem lekérése
A kiválasztott Tensor x, y és z koordinátájának a megadásával kiválasztunk egy elemet, majd kiírjuk az értékét.

4. Tensorok összeadása
Létrehozunk egy új azonos méretű Tensort, feltöltjük elemekkel, majd összeadjuk az első Tensorral. Az eredeti Tensor tartalmazza az összeadott értékeket. Csak két azonos méretű Tensort lehet összeadni.

5. Tensorok összeadása majd érték tárolása egy új Tensorban
Létrehozunk egy új azonos méretű Tensort, feltöltjük elemekkel, majd összeadjuk az első Tensorral. Az értékeket egy új Tensorban tároljuk el. Csak két azonos méretű Tensort lehet összeadni.

6. Tensor átméretezése
A kiválasztott Tensort tetszőlegesen átméretezzük.

7. Tensor feltöltése
A kiválasztott Tensor minden elemét feltöltjük egy általunk választott tettszőleges értékkel.

8. Tensor méretének lekérése
A kiválasztott Tensor méretét kiírjuk.

9. Tensor kirajzolása
A kiválasztott Tensort kirajzoljuk 2D-s Mátrixok sokaságaként: Amekkora a Tensor mélysége (Z mérete) annyi darab Mátrixot rajzolunk ki egymás alá. Elsődlegesen tesztelés szempontjából fontos, hogy a Felhasználó lássa a Tensorral történt változtatásokat.

10. Z sor adatainak kikérése X, Y tengelyen
A Tensornak egy általunk megadott X, Y koordinátájának a mentén kiírjuk a Z sor adatait.

11. Y sor adatainak kikérése X, Z tengelyen
A Tensornak egy általunk megadott X, Z koordinátájának a mentén kiírjuk az Y sor adatait.

12. X sor adatainak kikérése Y, Z tengelyen
A Tensornak egy általunk megadott Y, Z koordinátájának a mentén kiírjuk az X sor adatait.

13. Minden tárolt elem kitörlése
A kiválasztott Tensor összes elemét töröljük.

14. A belső tömb méretét átállítjuk 0-ra.
A belső tömböt átállítjuk 0-ra.

15. Belső tömb kikérése
Kiírjuk a belső tömb adatait.

16. Összes elem skaláris szorzata
A Tensor minden elemét megszorozzuk egy adott valós számmal.

17. Összes elem skaláris szorzata, eredmény elmentése egy új Tensorban
A Tensor minden elemét megszorozzuk egy adott valós számmal, majd az eredményt egy új Tensorban tároljuk.

18. Legnagyobb tárolt elem kikérése
Kiírjuk a legnagyobb tárolt elemet.

19. Legkisebb tárolt elem kikérése
Kiírjuk a legkisebb tárolt elemet.
