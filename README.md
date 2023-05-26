# Code explanation
This project follows the PageObject pattern, but is not limited to it, bringing a more suitable and easy-to-use solution for creating automated tests for the fictitious application "Automation Example".


### Solution explanation
Initially, the architecture was designed for two different projects (one for the tests themselves and another to isolate the reports and Selenium), both running on the same Solution, but this was discontinued during the validation of the idea. Currently the solution contains only one project that encompasses everything. This project was called *eCoreTestChallange* and is divided as follows:

##### CustomSelenium
Here we found classes about *SeleniumDriver* and custom elements as well as report classes
##### Data
Here we found our PageData Models and the file AppLabels.resx
> :bulb:**Tip**: The <ins>AppLabels.resx</ins> file stores all labels of application, so if something change all we have to do is change this file, cause the code looks to this file anyway
##### PageObjects
Here we find all PageObjects used and the PageObject Base class
##### Tests
Test class was sliced in two classes *TestBase* and *Test* where TestBase stores all hooks and Tests class stores all implemented Test Cases
> :memo: **Best practice**: It's a good idea to separate the Test Classes by feature or whatever, but in this case we adopted a single class to make the process easier, in view of the small amount of tests. 
> Even so, the **TestBase** class was created precisely with the intention of facilitating the creation of new classes.

### Report
This solution have a reporter that generates HTML files with the tests outcomes and another coll things. 
Unfortunatelly there was no time to implement everything that we want to bring on report. But it's a better way to see issues and problems automatically identified.

# Considerations on the proposed activity 

##### Test documentation

For this simulated case it was considered that the Test Documentation is correct. But, the TC002 Test Data is in conflict between a positive and a negative test, but this Test Data was maintained (and the test is failing).
About labels and format data there are several divergences between the application and the documentation. To assertions the documented was considered.
Test documentation don't provide system patterns or any info about the labels of the application. because of that the test considered wrong the label "Deposit Nowt" cause the word "Nowt" doesn't exist.
> :bug: :confused: In TC003 the test looks for "Deposit Now" column and fails, but if it is a mistake I gently ask you to change this value on *AppLabels.resx* file. Please do the same change if Test documentation is wrong when provide the "Wrong username or password" message (without a period) to the TC002