Feature: ProductPurchaseEndToEnd

The feature describes an end-to-end test scenario for purchasing products from the NopCommerce website.
Background: user will be on home page
@tag1
Scenario Outline: Purchase product from NopCommerce
    When user click on the Computers link
    Then user should be redirected to the Computers category page
	When user navigate to the category "<Category>"
    Then user should see the list of products in the selected "<Category>"
    When user select the product at position "<ProductPosition>"
    Then user should be redirected to the product page "<ProductName>"
    When user add the product to the cart
    Then user should see the cart page
    When user proceed to checkout as a new user
    Then user should see the registration page
    When user register as a new user with details "<Gender>","<First Name>","<Last Name>","<Email>","<Date>","<Month>","<Year>","<Company>","<Password>","<Confirm Password>"
    Then user should complete the registration and purchase the product successfully

 Examples:
      | Category   | ProductPosition | ProductName                          | Gender | First Name | Last Name | Email                         | Date | Month   | Year | Company  | Password | Confirm Password |
      | Notebooks  | 2               | asus-n551jk-xo076h-laptop            | M      | John       | Doe       | john.doe123459@gmail.com     | 13   | 10      | 1990 | ABC Inc. | password | password         |
      | Notebooks  | 3               | hp-envy-6-1180ca-156-inch-sleekbook  | F      | Jane       | Smith     | jane.smith23128@gmail.com      | 15   | 12      | 1985 | XYZ Corp | test123  | test123          |