
describe('Test Random Square Page', () => {
    const pageName = "random-square";
    it('visit and verify Random Square page', () => {
        cy.visit('http://localhost:3000').get('a[href=' + pageName + ']').click()
        cy.url().should('include', '/' + pageName)
        cy.get('a[href="home"]').contains('Home')
        cy.get('a[href="factorial"]').contains('Factorial')
        cy.get('a[href="fibonacci"]').contains('Fibonacci')
        cy.get('a[href="random-square"]').contains('Random Square')

        cy.get('h1').contains('Random square')
        cy.get('label[for="randomSquare_input"]').contains('Input a positive number to calculate square of a random smaller Integer')
        cy.get('button').contains('Calculate')
        cy.get('div[id="result"]').should('have.value', '')
        cy.get('p').contains('User inputs a number (n) in a textbox, then clicks a button to calculate Fib(n) via a corresponding API call. Then the correct result is displayed on the page.')

        cy.get('input[id="randomSquare_input"]').type(1).should('have.value', '1')
        cy.get('button').contains('Calculate').click()
        cy.get('div[id="result"]').contains('0')

        cy.get('input[id="randomSquare_input"]').clear().should('have.value', '')
        cy.get('button').contains('Calculate').click()
        cy.get('div[id="result"]').contains('Not Support')

    })
})