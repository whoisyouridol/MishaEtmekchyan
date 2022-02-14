--ფრჩხილებში დავწერე ზოგი ფრაზა იმის გამო, რომ აღვნიშნო კომანდების შესრულების პრიორიტეტი


--1.1) წამოიღე Accounts ცხრილიდან AccountID Currency სვეტები იმ პირობით, რომ აიდი მეტია 10-ზე და (ვალუტა არის USD ან (არ არის EUR და IsActive = 0))
SELECT AccountID, Currency FROM Accounts WHERE  AccountID > 10 AND (Currency = 'USD' OR  NOT Currency = 'EUR' AND  IsActive = 0)


--1.2) წამოიღე  Accounts ცხრილიდან ყველა სვეტი იმ პირობით, რომ (ფილიალის აიდი უდრის 5-ს და პროფილი არააქტიურია)
--(ან ექაუნთის აიდი ნაკლებია 100-ზე და ექაუნთის ტიპი უდრის 4-ს)
SELECT * FROM Accounts WHERE FilialID = 5 AND IsActive = 0 OR AccountID < 100 AND AccountTypeID = 4


--2) წამოიღე Accounts ცხრილიდან ყველა სვეტი იმ პირობით, რომ OpenDate იყო უფრო გვიანი ვიდრე 2017 წლის 1 აგვისტოს მერე და AccountNumber იწყება 'A'-თი და მთავრდება 1-ით
SELECT * FROM Accounts WHERE OpenDate > '2017-08-01 00:00:00.000' AND AccoutNumber LIKE 'A%1'


--3.1) IN : წამოიღე Customers ცხრილიდან ყველა ისეთ სვეტი, რომ CustomerID უდრის (ან 10-ს, ან 20-ს, ან 30-ს, ან 40-ს,ან 50-ს,
-- ან 60-ს,ან 70-ს,ან 80-ს,ან 90-ს,ან 100-ს) და IsJuridical უდრის 1-ს
SELECT * FROM Customers WHERE CustomerID IN(10,20,30,40,50,60,70,80,90,100) AND IsJuridical = 1


--3.2) BETWEEN : წამოიღე Customers ცხრილიდან სვეტი EmailAdress იმის გათვალისწინებით რომ,CustomerID იყოს  1 და 100 დიაპაზონში (BETWEEN 1-ს და 100-ს ჩათვლით დააბრუნებს დატას)
SELECT EmailAddress FROM CUSTOMERS WHERE CustomerID BETWEEN 1 AND 100


--4) წამოიღე Accounts ცხრილიდან ყველა სვეტი, რომლებსაც აქვთ CustomerID ისეთი, რომ Customers ცხრილში CustomerAddress იწყება D-თი
SELECT * FROM Accounts WHERE CustomerID IN (SELECT CustomerID FROM Customers WHERE CustomerAddress LIKE 'D%')

--5) წამოიღე Accounts ცხრილიდან Currency სვეტის მხოლოდ უნიკალური მნიშვნელობები (ფაქტობრივად DISTINCT ით მივიღებთ ყველა ვალუტას,
--ანუ რეზულტატში გვექნება USD, GPB, EUR)
SELECT DISTINCT Currency FROM Accounts


-- ეს კოდი დააბრუნებს ისეთ ველებს, სადაც არ იქნება 2 ველი ერთნაირი მნიშვნელობებით, ანუ მაგალითად არ გამეორდება 2 ველი
-- მნიშვნელობებით CustomerID = 10, ProductID = 2, თუმცა შესაძლებელია რომ იყოს 2 ან მეტი ველი სადაც ProductID = 2. DISTINCT 2 და მეტ სვეტისთვის ამოწმებს
-- მასში შემავალ სვეტებს ერთად და მთლიანობაში თუ ველი მეორდება მხოლოდ მაშინ ადისთინქთებს
SELECT DISTINCT CustomerID,ProductID from Deposits


--6)ეს LIKE აბრუნებს Customers ცხრილის ყველა ისეთ ველს, რომლების EmailAddress იწყება Nicole-ით, რომელში არის "." და ისეთ @,
--რომლის წინ არის 1 მაინც სიმბოლო და  მეილი მთავრდება gmail.com ით, ანუ ვეცადე ისეთი LIKE დამეწერა, რომელიც შეამოწმებს, სწორ ფორმატში თუ არის მითითებული მეილი
SELECT * FROM Customers WHERE EmailAddress LIKE 'Nicole%.%_@%gmail.com'


--ეს LIKE დააბრუნებს Accounts ცხრილის ისეთ AccountsNumber-ებს, რომლების იწყებიან 2-ით, შეიცავენ 96, ასევე შეიცავენ 5-ს იმ პირობით, რომ 5-ის წინ იქნება სულ ცოტა
--1 სიმბოლო და 5-ის მერე იქნება სულ ცოტა 2 სიმბოლო და ასევე AccountNumber უნდა მთავრდებოდეს 'F' სიმბოლოთი
SELECT AccoutNumber FROM Accounts WHERE AccoutNumber LIKE '2%96%_5__%F'


--7) INNER ამ კოდით ვაერთიანებ Customers და Deposits ცხრილები ასეთი პრინციპით : თუ ორივე ცხრილში მოიძებნა ერთი და CustomerID, მაშინ სტრიქონი ორივე ცხრილიდან გაერთიანდება ამ აიდის მიხედვით,
--თუ CustomerID არ მოიძებნა რომელიმე ცხრილში, მაშინ არაფერი არ მოხდება, პროგრამა გააგრძელებს შესრულებას და არ დაამატებს მონაცემებს არც 1, არც მე-2 ცხრილიდან
SELECT * FROM Deposits JOIN Customers ON Deposits.CustomerID = Customers.CustomerID

--7) RIGHT ამ კოდით ვითხოვ DepositID, Deposits.CustomerID,Customers.CustomerID სვეტებს შემდეგი პრინციპით : Customers-ებში თუ მოიძებნა ისეთი CustomerID,
--რომელიც არის Accounts-ებში, მაშინ დაბრუნდება 3-ვე შევსებული ველი,შეივსება შემდეგი პრინციპით : თუ ქასთომერის აიდი ორივე თეიბლში დაემთხვა, მაშინ შეივსება
--ორი ცხრილის შესაბამისი ველების "გაერთიანებით", ხოლო თუ არა მაშინ Customers-ების ნაწილი შეივსება CustomerID - ის შესაბამისი ველების დატით და Deposits - ების ველები NULL - ები იქნება
SELECT DepositID, Deposits.CustomerID,Customers.CustomerID FROM Deposits RIGHT JOIN Customers ON Deposits.CustomerID = Customers.CustomerID


--LEFT ეს კოდი დააბრუენბს გაერთიანებულ Accounts და Deposits ცხრილებს ასეთი პრინციპით : მარტივად რომ ავხსნათ დააბრუნებს სრულყოფილ შევსებულ ცხრილს თუ მოიძებნება
--ისეთი Customer, რომელსაც აქვს 1 მაინც დეპოზიტი, წინააღმდეგ შემთხვევაში Deposits-ების ნაწილს ყველგან NULL-ები ექნება და Customers ების მხარე დარჩება შევსებული. 
--RIGHT JOIN თუ იქნებოდა აბსოლუტურად იგივენაირად იმუშავებდა კოდი, ოღონდ ახლა თუ არ დაემთხვევოდა ID-ები, ახლა უკვე Customers ები შეივსეობდა NULL-ებით
--(უფრო ვრცელი ახსნა მაქვს RIGHT JOIN ის აღწერაში, პრინციპი იგივეა და აქ ვეცადე სხვანაირად ამეხსნა)
SELECT * FROM Customers LEFT JOIN Deposits ON  Customers.CustomerID = Deposits.CustomerID


--FULL FULL JOIN არის ფაქტობრივად RIGHT JOIN + LEFT JOIN. კოდის ახნსა : თუ მარჯვენა ცხრილში ვერ ნახა შესაბამისი აიდი, მაშინ სტრიქონის ის ნაწილი,
--რომელიც ეკუთვნის Customers-ებს NULL-ები ხდება da Loans-ების ნაწილი უცვლელი რჩება, იგივე პრინციპით მუშაობს მარცხნიდან მარჯვნივ : მარცხენაში თუ ვერ იპოვა აიდი, a-NULL-ებს Loans-ების ნაწილს
--და Customers-ების ნაწილი რჩება უცვლელი
SELECT * FROM loan.Loans FULL JOIN Customers ON Customers.CustomerID = loan.Loans.CustomerID
