import React, { Component } from 'react';
import '../../assets/css/Default.css';
import '../../assets/css/Index.css'
import Header from '../../assets/components/Header';
import Footer from '../../assets/components/Footer';

class App extends Component {
  render() {
    return (
      <div>
      <Header />
      <div class="structure">
     <div class="first-container">
         <h1>Tudo começa com planejamento</h1>
         <p>Já pensou em como organizar seus desejos e objetivos de modo rápido e prático?</p>
         <p>Com o DreamWish, você consegue!</p>
     </div>
     <img src="../Telas/ListaDesejos.png" draggable="false" height="350px" width="250px" alt="img" />
     <div class="second-container">
         <h1>Acredite em Você</h1>
         <p>Queremos lhe ajudar a realizar seus desejos! Foca no presente para conquistar suas coisas no futuro.
         </p>
         <p>Faça o seu melhor agora! Você é capaz.</p>
         <button>Vá em frente</button>
     </div>
     </div>
     <Footer />
     </div>
    )
  }
}

export default App;
