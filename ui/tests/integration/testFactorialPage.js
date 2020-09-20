
describe('Test Factorial Page', () => {
    const pageName = "factorial";
    it('visit and verify Factorial page', () => {
        cy.visit('http://localhost:3000').get('a[href=' + pageName +']').click()
        cy.url().should('include','/'+pageName)
        cy.get('a[href="home"]').contains('Home')
        cy.get('a[href="factorial"]').contains('Factorial')
        cy.get('a[href="fibonacci"]').contains('Fibonacci')
        cy.get('a[href="random-square"]').contains('Random Square')

        cy.get('h1').contains('N!')
        cy.get('label[for="factorial_input"]').contains('Input a number to calculate its factorial')
        cy.get('input#factorial_input').invoke('attr','placeholder').should('contain','1~10')
        cy.get('button').contains('Calculate')
        cy.get('div[id="result"]').should('have.value', '')
        cy.get('p').contains('User inputs a number (n) in a textbox, then clicks a button to calculate n! via a corresponding API call. Then the correct result is displayed on the page.')

        cy.get('input[id="factorial_input"]').type(1).should('have.value', '1')
        cy.get('button').contains('Calculate').click()
        cy.get('div[id="result"]').contains('1')

    })
}
)