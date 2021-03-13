Feature: Application Contact Us Page
     A user tries to view a larger map in the contact us page 
  
  @functional
  Scenario: A site visitor in the contact page clicks the view larger map
    Given User navigates to "contact" page
    When Clicks on view larger map button
    Then A new window with map is open 
   