let numeroSecreto = Math.floor(Math.random() * 100) + 1;
let contador = 0;
let maxIntentos = 3;
let juegoTerminado = false;

function verificar(){

    if(juegoTerminado) return;

    let numeroJugador = parseInt(document.getElementById("numero").value);
    let mensaje = document.getElementById("mensaje");
    let intentos = document.getElementById("intentos");

    if(isNaN(numeroJugador)){
        mensaje.textContent = "⚠️ Escribe un número válido";
        return;
    }

    contador++;

    if(numeroJugador < numeroSecreto){
        mensaje.textContent = "🔼 El número es mayor";
    }
    else if(numeroJugador > numeroSecreto){
        mensaje.textContent = "🔽 El número es menor";
    }
    else{
        mensaje.textContent = "🎉 ¡Ganaste!";
        juegoTerminado = true;
        return;
    }

    intentos.textContent = "Intentos restantes: " + (maxIntentos - contador);

    if(contador >= maxIntentos){
        mensaje.textContent = "💀 Perdiste. El número era " + numeroSecreto;
        juegoTerminado = true;
    }
}

function reiniciar(){
    numeroSecreto = Math.floor(Math.random() * 100) + 1;
    contador = 0;
    juegoTerminado = false;

    document.getElementById("mensaje").textContent = "";
    document.getElementById("intentos").textContent = "";
    document.getElementById("numero").value = "";
}
