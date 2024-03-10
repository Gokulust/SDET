Feature: AddAndRemoverProductFromWishList

A short summary of the feature

@E2E-AddAndRemoveProductFromWishList
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
    When User add the product to the wish list
    Then User wait for the wish list page with selected product to load
    When User remove the product from the wish list
    Then User check if the wish list is empty
Examples: 
    | productName | productNumber |
    | hp laptop   | 2             |
