Синхронизация – имплементация в .NET – за създаване на примерите е използвано Visual Studio 2017, като имплементацията е показана в конзолно приложение (Console Application .NET Framework). Примерите са разделени в различни класове, като целта е да се покаже използването на критични секции чрез – lock, Monitor.{Enter, Exit}, показан е и пример, в който няма синхронизация.

Как работи примерът? – Идеята на приложението е да покаже банкова сметка с баланс и суми за зареждане и изпразване на сметката. 

Класовете, които са използвани в приложението са: 
-	MainThread – съдържа Main функцията на приложението;
-	BankAccount – базов клас с полета за баланс и методи за внасяне и извличане на пари от сметка;
-	BankTransaction – клас който се занимава за създаване на транзакции, всяка от които е извикана 3 пъти;
-	SyncWithLock, SyncWhitMonitor – класове, които показват синхронизирани транзакции.

Примери:

1) При несинхронизирана транзакция – Ако имаме сметка с баланс от 0 лв. и сума за вноска от 100 лв. и сума за извличане 90 лв. е много вероятно да получим отговор – „There aren't enough money in the account.\nTrying to withdraw: {withdraw}, from balance - {balance}”.  Това се получава, защото нишката, която тегли пари достъпва общия ресурс balance, който въпреки че е захранен от нишката за вноска, все още има стойност 0 лв;

2) При синхронизирана транзакция(lock, Monitor) – Първо в сметката ще се извършат 3 вноски и след това ще може да се извършат 3 тегления, ако сумата е достатъчна за тях (което е и главната цел на примера). 
