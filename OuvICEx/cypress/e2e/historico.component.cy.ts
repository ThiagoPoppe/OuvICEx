/// <reference types="cypress" />

import { inRange } from "cypress/types/lodash"

describe('example to-do app', () => {
    beforeEach(() => {

      cy.visit('http://localhost:4200')
    })

    it('navigation', ()=>{
        cy.get('#historico-btn').click()
        cy.url().should('include','historico')

        cy.get('#reclame-btn').click()
        cy.url().should('include','reclame');

        cy.get('#estatisticas-btn').click()
        cy.url().should('include','estatistica')

        cy.get('#home-btn').click()
        cy.contains('Como Funciona?')

        cy.get('#signin-btn').click()
        cy.url().should('include','registre')
    })

    it('Own Posts', ()=>{


        cy.get('#historico-btn').click()
        cy.url().should('include','historico')

        cy.get('#grid').contains('Eu Sou o Usuário 1')
        cy.get('#grid').contains('Eu Sou o Usuário 2').should('not.exist')
    })
    

    it('Submit Private', ()=>{
        cy.get('#reclame-btn').click()
        cy.url().should('include','reclame');

        cy.get('#title').type("Test Title Private")

        cy.get('#text').type('This is a test. Please test something.')

        cy.get('#context').select('Reclamação')

        cy.get('#authorDepartamentId').select('DCC')

        cy.get('#targetDepartamentId').select('DMAT')

        cy.get('#userId').type('1')

        cy.get('#submit-btn').click()

        cy.wait(2000)

        cy.on('window:alert',(t)=>{
            //assertions
            expect(t).to.contains('Enviado');
        })
    })

    it('View Private Posts', ()=>{
        cy.get('#historico-btn').click()
        cy.url().should('include','historico')

        cy.get('#grid').children().contains('Test Title Private')

        cy.get('#own-posts').click()
        cy.get('#grid').contains('Test Title Private').should('not.exist')
    })

    it('Submit Public', ()=>{
        cy.get('#reclame-btn').click()
        cy.url().should('include','reclame');

        cy.get('#title').type("Test Title Public")

        cy.get('#text').type('This is a Public test. Please test something.')

        cy.get('#context').select('Elogio')

        cy.get('#authorDepartamentId').select('DCC')

        cy.get('#targetDepartamentId').select('DMAT')

        cy.get('#permissionToPublicate').check()

        cy.get('#userId').type('2')

        cy.get('#submit-btn').click()

        cy.wait(2000)

        cy.on('window:alert',(t)=>{
            //assertions
            expect(t).to.contains('Enviado');
        })
    })

    it('View Public Posts', ()=>{
        cy.get('#historico-btn').click()
        cy.url().should('include','historico')

        cy.get('#grid').children().contains('Test Title Public').should('not.exist')

        cy.get('#own-posts').click()
        cy.get('#grid').children().contains('Test Title Public')
    })

    it('Filters', ()=>{

        cy.get('#historico-btn').click()
        cy.url().should('include','historico')
        cy.get('#own-posts').click()

        cy.get('#DepartamentoReferenciado').select('DCC')

        cy.get('#submit-btn').click()


        cy.get('#DepartamentoAutor').select('DMAT')

        cy.get('#submit-btn').click()


        cy.get('#context').select('Reclamação')

        cy.get('#submit-btn').click()


        cy.get('#own-posts').click()

    })

    it('View Private Posts on Another Account', ()=>{


        localStorage.setItem('user', '2');
        cy.get('#historico-btn').click()
        cy.url().should('include','historico')
        
        cy.get('#grid').children().contains('Test Title Private').should('not.exist')

        cy.get('#own-posts').click()

        cy.get('#grid').children().contains('Test Title Private').should('not.exist')

        
    })

    it('Stats', ()=>{
        cy.get('#estatisticas-btn').click()
        cy.url().should('include','estatistica')

        cy.get('#status').click()

        cy.get('#context').click()
    })
    
})