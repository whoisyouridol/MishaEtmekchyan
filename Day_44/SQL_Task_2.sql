--1) Deposits-ის თითო row გაერთიანდება Loans-ის თუ თითო ცხრილში დაემთხვევა CustomerID,ანუ მოიძებნება ისეთი მომხმარებელი, რომელსაც აქვს როგორც დეპოზიტი, ასევე სესხი. 
--DISTINCT იმის გამო უნდა იყოს, რომ მომხმარებელს შეიძლება გააჩნდეს რამდენიმე სესხი ან დეპოზიტი და შესაბამისად ჯოინის დროს დუბლირება მოხდება, DISTINCT კი მოაშორებს ამ დუბლირებას
SELECT DISTINCT dep.CustomerID FROM Deposits AS dep JOIN loan.Loans AS loan ON loan.CustomerID = dep.CustomerID


--1) ასევე მეტი უსაფრთხოებისთვის შეიძლება დავაჯოინოთ მიღებული პასუხი Customers ცხრილს რადგან არ მოხდეს ისეთი სიტუაცია,
--რომ Deposits და Loans ებში CustomerID არის და Customers-ებში შესაბამისი აიდი არ არსებობს
SELECT DISTINCT cus.CustomerID FROM Deposits AS dep JOIN loan.Loans AS loan ON loan.CustomerID = dep.CustomerID JOIN Customers AS cus ON dep.CustomerID = cus.CustomerID


--2.1) რეალურად INNER JOIN Deposits და Loans ცხრილებზე გავაკეთე პირველ დავალებაში :
--Deposits-ის თითო row გაერთიანდება Loans-ის თუ თითო ცხრილში დაემთხვევა CustomerID,ანუ მოიძებნება ისეთი მომხმარებელი, რომელსაც აქვს როგორც დეპოზიტი, ასევე სესხი. 
SELECT dep.DepositID,dep.CustomerID,loan.LoanID,loan.CustomerID FROM Deposits AS dep JOIN loan.Loans AS loan ON loan.CustomerID = dep.CustomerID


--2.2) LEFT : ეს ჯოინი რეალურად დაგვიბრუნებს იმ ხალხს, ვისაც აქვს დეპოზიტი, და შესაძლოა ჰქონდეს სესხი. თუ აქვს სესხი ჩვეულებრივად შესაბამისი CustomerID-ის
--მიხედვით მიანიჭებს ყველა row-ს მნიშვნელობას (სესხების მხარეს ცხრილში) ხოლო თუ არ გააჩნია სესხი, NULL - ები იქნება სესხების row-ების ნაწილი
SELECT * FROM Deposits AS dep LEFT JOIN loan.Loans AS loan ON loan.CustomerID = dep.CustomerID

--2.3) RIGHT ამ ჯოინის პრინციპი იგივეა, ოღონდ ახლა "პრიორიტეტი" არის სესხები. მომხმარებელს თუ ექნება სესხი და დეპოზიტი - ორივე ველს შეავსებს, ხოლო თუ გააჩნია მხოლოდ სესხი,
--Deposits-ების row-ები NULL ები იქნება, მაგრამ სესხების ნაწილი ყველა ვარიანტში შევსებული იქნება, იმიტომ რომ აქ სესხების CustomerID-ებს ვადარებთ იმათ, რომლებიც არიან Deposits-ებში,
--და LEFT JOIN ში პირიქით ვაკეთებდით და მაგიტომ LEFT ის შემთხვევაში Deposits ების ნაწილი ყოველთვის შევსებული იყო, და აქ პირიქითაა
SELECT * FROM Deposits AS dep RIGHT JOIN loan.Loans AS loan ON loan.CustomerID = dep.CustomerID


--2.4)FULL ამ შერჩევაში მოხვდება ის ხალხი, ვისაც აქვს სესხი და არ აქვს დეპოზიტი, აქვს დეპოზიტი და არ აქვს სესხი და ასევე ის ხალხი, რომლებსაც აქვს სესხი და დეპოზიტი.
SELECT * FROM Deposits AS dep FULL JOIN loan.Loans AS loan ON loan.CustomerID = dep.CustomerID


--3) პირველ 2 ჯოინში ამოვარჩიე ისეთი მომხმარებლები, რომლებსაც გააჩნია დეპოზიტი და სესხი, მე-3 ჯოინში ვიპოვე ისეთი ექაუნთები, რომლებზეც არის სესხი,
--მე-4 ჯოინში  Accounts ცხრილში ვიპოვე ისეთი სრული ინფორმაცია ექაუნთზე, რომელსაც გააჩნია სესხი და ასევე იმ პირობით, რომ აქტიური ექაუნთია.
--distinct-ით მოვაშორე დუბლირებები
SELECT DISTINCT c.CustomerID,a.CustomerID, a.IsActive FROM Deposits AS d 
join Customers AS c ON c.CustomerID = d.CustomerID
join loan.Loans AS l ON l.CustomerID = c.CustomerID
join loan.LoanAccounts AS la ON la.LoanID = l.LoanID
join Accounts AS a ON a.AccountID = la.AccountID
WHERE a.IsActive = 1


--4)ამ მაგალითში კოდიც კი არ იმუშავებს, იმიტომ, რომ ვადარებ int-ს და varchar-ს. 
SELECT * FROM loan.Loans AS l JOIN loan.Products AS p ON p.ProductName = l.CustomerID


--4.1)ხოლო ამ შემთხვევაში არ არის ვალიდური იმის გამო, რომ ექაუნთების აიდის ვადარებ ოვერდრაფტის აიდის, რაც არ არის სწორი და არეული შედეგები მექნება.
SELECT * FROM Accounts AS a JOIN OverDrafts as od ON a.AccountID = od.ID


--5) slack-ში გამოვაგზავნე


--6) Customers >> Accounts one-to-many
-- Customers >> Loans one-to-many
-- Loans >> LoanAccounts one-to-one
-- Customer >> Deposits one-to-many
-- Accounts >> Overdrafts one-to-many
-- Transactions >> Accounts one-to-many
-- TransactionTypes >> Transactions one-to-many


--7)ტრანზაქციების ცხრილიდან გავდივარ ექაუნთების ცხრილზე იმ პირობით, თუ ვნახე debit ის ან credit ის აიდი ექაუნთების ცხრილში, ხოლო შემდეგ ექაუნთებიდან 
--გავდივარ მომხმარებლების ცხრილზე, საიდანაც შესაბამისად ვიღებ სახელს და გვარს.
SELECT  DISTINCT cus.CustomerFirstName, cus.CustomerLastName FROM Transactions  AS tr JOIN Accounts as acc ON
tr.DebitAccountID = acc.AccountID OR tr.CreditAccountID = acc.AccountID
JOIN Customers AS cus ON cus.CustomerID = acc.CustomerID


--8) ვეძებ მომხმარებლების ცხრილში მომხმარებლებს ჩემთვის საჭირო აიდით : ეს აიდი უნდა იყოს როგორც დეპოზიტების ცხრილში, ასევე სესხების ცხრილში, 
--ამას მივაღწევ IN და AND ის გამოყენებით
SELECT cus.CustomerID FROM Customers AS cus WHERE cus.CustomerID 
IN (SELECT dep.CustomerID from Deposits AS dep) AND 
cus.CustomerID IN (SELECT loan.CustomerID FROM loan.Loans AS loan)


--9) ეს ხდება იმიტომ, რომ მომხმარებელს აიდით 115 გააჩნია 2 დეპოზიტი და 9 სესხი და ჯოინს ისეთი მუშაობის პრინციპი აქვს,
--რომ 1 ცხრილიდან იღებს 1 row-ს და ადარებს სხვა ცხრილის ყველა rows. ავხსნი 1-ის მაგალითზე, დანარჩენ 8-სთვის იგივი პრინციპით იმუშავებს. გვაქვს LoanID = 11 და CustomerID = 115. Deposits ებში 2 დეპოზიტი ნახა რომელსაც აქვს CustomerID = 115, და შესაბამისად გააერთიანა.
--ზუსტად ამიტომ, გვაქვს დამოკიდებულება, რომ 2 დეპოზიტიდან და 9 სესხიდან მივიღეთ 18 ჩანაწერი. ეს მოხდა იმის გამო, რომ 1 სესხების row-დან მივიღეთ 2 გაერთიანებული row.
SELECT * FROM loan.Loans as l JOIN Deposits as d ON l.CustomerID = d.CustomerID WHERE l.CustomerID = 115
