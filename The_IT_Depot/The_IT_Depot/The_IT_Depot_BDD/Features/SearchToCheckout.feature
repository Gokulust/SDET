Feature: SearchToCheckout

Aims to test the end-to-end flow from searching for a product to checking out.

@E2E-SearchToCheckout
Scenario: Search for a product, add it to the cart, and proceed to checkout
    Given User will be on Homepage
    When User search for "<productName>" on the home page
    And User click on the search button
    Then User wait for the search results page to load with title "<productName>"
    When User click on the subcategory checkbox
    And User click on the sort by selection box
    And User select the sort by option high to low
    And User click on the product with product number "<productNumber>"
    Then User wait for the selected product page to load
    When User click on the add to cart button
    Then User wait for the cart page to load with the selected product
    When User click on the checkout button
    Then User wait for the checkout page to load with the selected product
Examples: 
    | productName | productNumber |
    | hp laptop   | 2             |
