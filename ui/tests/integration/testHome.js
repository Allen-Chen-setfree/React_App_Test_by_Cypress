
describe('Test Home Page', () => {
    it('visit factorial page', () => {
        cy.visit('http://localhost:3000')
        cy.get('h1').contains('Home')
        cy.get('h2').contains('Welcome to the automated QA specialist code task!')
        cy.get('p').contains('Please read readme.md at the root folder')
        cy.get('a[href="home"]').contains('Home')
        cy.get('a[href="factorial"]').contains('Factorial')
        cy.get('a[href="fibonacci"]').contains('Fibonacci')
        cy.get('a[href="random-square"]').contains('Random Square')
        
    })
})