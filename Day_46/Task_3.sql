--1) წინა დავალებაში ზუსტად ასეთი ტასკი იყო
--ვეძებ მომხმარებლების ცხრილში მომხმარებლებს ჩემთვის საჭირო აიდით : ეს აიდი უნდა იყოს როგორც დეპოზიტების ცხრილში, ასევე სესხების ცხრილში, 
--ამას მივაღწევ IN და AND ის გამოყენებით
SELECT cus.CustomerID FROM Customers AS cus WHERE cus.CustomerID 
IN (SELECT dep.CustomerID from Deposits AS dep) AND 
cus.CustomerID IN (SELECT loan.CustomerID FROM loan.Loans AS loan)


--2) ამას მივაღწევ ISNULL ფუნქციის გამოყენებით, სადაც ნახავს რომ Purpose = NULL, შეცვლის Undefined-ად
SELECT LoanID,CustomerID,Amount,Currency, ISNULL(Purpose,'Undefined') AS Purpose FROM loan.Loans


--3)წამოვიღე მეილის სუბსტრინგი სულ დასაწყისიდან @ სიმბოლომდე იმ პირობით, რომ @-ის მერე მექნება gmail.com
SELECT SUBSTRING(EmailAddress,1,CHARINDEX('@gmail.com',EmailAddress) - 1) FROM Customers


--4)WHERE ით და LEN-ით ვფილტრავ იმ ხალხს, ვისაც სახელის სიგრძე მეტია 7-ზე
SELECT * FROM Customers WHERE LEN(CustomerFirstName) > 7


--5)ვამატებ იმდენ დღეს, რამდენიც არ მყოფნის რომ 18000 დღის ვითო (ამას 18000 - ით - DATEDIFF ით ვითვლი) და შემდეგ ვანგარიშობ,
--რომდენი დრო გავა აწმყოდან
SELECT DATEADD(DAY,18000 - DATEDIFF(DAY,'2001/11/20',GETDATE()),GETDATE())


--6)აქ ჩვეულებრივად DATEDIFF ით ვითვლი
SELECT *,DATEDIFF(DAY,StartDate,EndDate) AS Days FROM loan.Loans

--7)აქ ვითვლი სხვაობას დაბადების თარიღისა და აწმყოს შორის 
SELECT *,DATEDIFF(MONTH,BirthDate,GETDATE()) AS DaysFromBirthDay FROM Customers


--9.1)რამდენი ადამიანი თითო შტატში ცხოვრობს
SELECT COUNT(CustomerID) as Amount, State from customers group by State 


--9.2) რამდენი ადამიანი ცხოვრობს თითო შტატის თითო ქალაქში
SELECT COUNT(CustomerID) AS Amount, State,City FROM customers GROUP BY State,City


--10) ვაჯოინებ Accounts ებთან იმისთვის რომ გავარკვიო, კრედიტ-აიდი ან დებიტ-აიდი არის საერთოდ თუ არა ექაუნთებში,
--მერე group by ით დუბლირებებს ვიშორებ, sum ით ჯამს ვითვლი, და შემდეგ order by ით აიდი-ების მიმართ ვალაგებ
SELECT acc.AccountID,SUM(tr.Amount) FROM Transactions AS tr join Accounts AS acc ON tr.CreditAccountID = acc.AccountID or tr.DebitAccountID= acc.AccountID
GROUP BY acc.AccountID
ORDER BY acc.AccountID

--11) ტრანზაქციების ცხრილიდან გავდივარ ექაუნთების ცხრილზე, ექაუნთების ცხრილიდან მომხმარებლების ცხრილზე,ხოლო შემდეგ ვაჯგუფებ
--მომხმარებლის აიდის მიხედვით, და ვითვლი ტრანზაქციების ჯამს
SELECT cus.CustomerID,SUM(tr.Amount) FROM Transactions AS tr join Accounts AS acc ON tr.CreditAccountID = acc.AccountID or tr.DebitAccountID= acc.AccountID
JOIN Customers AS cus ON cus.CustomerID = acc.CustomerID
GROUP BY cus.CustomerID
ORDER BY cus.CustomerID

--12. დავადგინოთ ვალუტის ჭრილში რა სესხის თანხა გაიცა ჯამურად (შემდეგ ვალუტას დავამატოთ პროდუქტების და ფილიალების ჭრილშიც)
--12.1) ვალუტის ჭრილში
SELECT SUM(Amount) SumAmount, Currency FROM loan.Loans GROUP BY Currency

--12.2) პროდუქტების ჭრილში + ვალუტა
SELECT SUM(Amount) SumAmount,ProductID, Currency SumAmount FROM loan.Loans GROUP BY ProductID, Currency
--12.3) ფილიალების ჭრილში + ვალუტა
SELECT SUM(Amount) SumAmount,FilialID, Currency FROM loan.Loans GROUP BY Currency, FilialID
--13)დავაჯგუფე აიდის მიხედვით, count ით დავთვალე რაოდენიბა, MAX & MIN ით შესაბამისად მაქსიმალური და მინიმალური სესხები, order by - ით დავსორტე
SELECT CustomerID, COUNT(CustomerID) AmountOfCustomers, MAX(Amount) MaxLoan, MIN(Amount) MinLoan FROM loan.Loans 
GROUP BY CustomerID 
ORDER BY CustomerID


--14)მთავარი ნაწილი წამოვიღე 10) დავალებიდან და ამ დავალებისთვის არსებული კოდის პატარა რედაქტირება დამჭირდა
SELECT COUNT(cus.CustomerID) AmountOfTransactions,cus.CustomerID,MIN(tr.TransactionDate) FROM Transactions AS tr join Accounts AS acc ON
tr.CreditAccountID = acc.AccountID or tr.DebitAccountID= acc.AccountID
JOIN Customers AS cus ON cus.CustomerID = acc.CustomerID
GROUP BY cus.CustomerID
ORDER BY cus.CustomerID


--15)აქ უბრალოდ გავფილტრე ვალუტით  და მერე ჯამი დავთვალე
SELECT CustomerID FROM loan.Loans WHERE Currency = 'USD' GROUP BY CustomerID HAVING  SUM(Amount) > 5000

--16)ვიპოვნოთ მომხმარებლებში ხომ არ მოიძებნება ისეთი პიროვნებები ვინც ერთ ქუჩაზე ცხოვრობენდა ვაჩვენოთ რომელ ქუჩაზე და რამდენი ?
SELECT CustomerAddress, COUNT(CustomerID),COUNT(SUBSTRING(CustomerAddress,1,CHARINDEX('#',CustomerAddress) - 2)) FROM Customers GROUP BY CustomerAddress 

--ამ ცხრილში ვერ ვიპოვე ერთნაირი ქუჩები და თუ იქნება ამ სკრიპრით შეგვიძლია მოვაშოროთ ნომერი და შევადაროთ ერთმანეთს მხოლოდ
--ქუჩების სახელები : substring(CustomerAddress,1,CHARINDEX('#',CustomerAddress) - 2)

--select count(substring(CustomerAddress,1,CHARINDEX('#',CustomerAddress) - 2)),count(customerID) from Customers 
