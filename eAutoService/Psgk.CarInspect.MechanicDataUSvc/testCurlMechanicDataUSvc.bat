echo Get all mechanics:
curl -X "GET" "https://localhost:7258/Mechanic/DisplayAllMechanics" -H "accept: text/plain"

echo Mechanic with Name John:
curl -X "GET" "https://localhost:7258/Mechanic/FindMechanicByName/John" -H "accept: text/plain"

echo Mechanic with Surname Smith:
curl -X "GET" "https://localhost:7258/Mechanic/FindMechanicBySurname/Smith" -H "accept: text/plain"

echo Mechanic with Workplace Manchester:
curl -X "GET" "https://localhost:7258/Mechanic/FindMechanicByWorkPlace/Manchester" -H "accept: text/plain"

echo Adding Mechanic Walter Sideeye:
curl -X "POST" "https://localhost:7258/Mechanic/AddMechanic/Walter/Sideeye/Spain" -H "accept: */*" -d ''

echo Checking if Walter Sideeye was added:
curl -X "GET" "https://localhost:7258/Mechanic/DisplayAllMechanics" -H "accept: text/plain"

echo Deleting Mechanic with id number 15:
curl -X "POST" "https://localhost:7258/Mechanic/DeleteMechanic/15" -H "accept: */*" -d ''

echo Checking if Walter Sideeye was deleted:
curl -X "GET" "https://localhost:7258/Mechanic/DisplayAllMechanics" -H "accept: text/plain"

pause
