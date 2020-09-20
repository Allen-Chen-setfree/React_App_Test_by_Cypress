
describe('Test Fibonacci Page', () => {
    const pageName = "fibonacci";
    it('visit and verify Fibonacci page', () => {
        cy.visit('http://localhost:3000').get('a[href=' + pageName + ']').click()
        cy.url().should('include', '/' + pageName)
        cy.get('a[href="home"]').contains('Home')
        cy.get('a[href="factorial"]').contains('Factorial')
        cy.get('a[href="fibonacci"]').contains('Fibonacci')
        cy.get('a[href="random-square"]').contains('Random Square')

        cy.get('h1').contains('Fib(n)')
        cy.get('label[for="fibonacci_input"]').contains('Input a number to calculate its fibonacci')
        cy.get('input#fibonacci_input').invoke('attr', 'placeholder').should('contain', '0~10')
        cy.get('button').contains('Calculate')
        cy.get('div[id="result"]').should('have.value', '')
        cy.get('p').contains('User inputs a number (n) in a textbox, then clicks a button to calculate Fib(n) via a corresponding API call. Then the correct result is displayed on the page.')

        cy.get('input[id="fibonacci_input"]').type(0).should('have.value', '0')
        cy.get('button').contains('Calculate').click()
        cy.get('div[id="result"]').contains('0')

    })

})