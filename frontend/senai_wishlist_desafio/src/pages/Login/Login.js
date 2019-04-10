import React, { Component } from 'react';
import '../../assets/css/Default.css';
import '../../assets/css/Login.css'

class Login extends Component{
    constructor(){
        super()
        this.state = {
            email: "",
            senha: ""
        }
        this.verificarUsuario = this.verificarUsuario.bind();
    }
    verificarUsuario(){
        fetch('http://localhost:3000/Desejos',{
            method: "POST",
            email: this.state.email,
            senha: this.state.senha
        })
        .then(data => {
            if(data === 200){
                localStorage.setItem("userWish", data.data.token);
                this.props.history.push("/Desejos")
            }
        })
        .catch(erro => {this.setState({erroMessage : "Email ou senha inválidos"})})
    }
    usuarioAutenticado = () => localStorage.getItem("userWish") != null;
    render(){
        return(
            <div class="main">
            <section class="main-container">
            <h1>Faça o login para entrar:</h1>
            <form>
                <input type="email" placeholder="Insira seu Email..." />
                <input type="password" placeholder="Insira sua Senha..." />
                <button type="submit">Entrar</button>
                </form>
                </section>
                </div>
        )
    }
}
export default Login;