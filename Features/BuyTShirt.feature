Feature: Buy T-Shirt
As a Customer I want to buy a T-Shirt to complete a full purchase transaction.

    Background:
        Given I am logged in to Swag Labs as a standard user

    Scenario: View T-Shirt details and add to cart
        When I view the details of the Sauce Labs Bolt T-Shirt
        And I add the Sauce Labs Bolt T-Shirt to the cart for $15.99
        And I view the shopping cart
        Then I should see the Sauce Labs Bolt T-Shirt in my cart with the correct price

    Scenario: Complete T-Shirt purchase
        When I add the Sauce Labs Bolt T-Shirt to the cart for $15.99
        And I view the shopping cart
        And I proceed to checkout
        And I fill in the checkout form with my info: 'John', 'Script', '12345'
        And I click the Continue button
        And I click the Finish button on Checkout overview page
        Then I have finished my shopping