let scroll = 0;
let Criaturas = '';
let UltimaCriatura;
let Resultado= document.querySelector('#Resultado');
Resultado.innerHTML= '';
var CantidadCriaturas;


function ContarCriaturas() {
    let apiUrl = 'https://localhost:44373/Criatura/GetContarTotalCriaturas';
	try {
		const respuesta = new XMLHttpRequest;
        respuesta.open('GET',apiUrl,true)
        respuesta.send();

        respuesta.onreadystatechange = function(){
            if (this.readyState== 4 && this.status ==200) {
                //console.log(this.responseText)
                let datos = JSON.parse(this.responseText);
                //console.log(datos)   
                for (let e of datos){
                    console.log("MAX  "+e.max);
                    CantidadCriaturas =  e.max;
                    
                }
                
            }            
        }
	} catch(error){
		console.log(error);
	}
}

console.log("Cantidad criatura " + ContarCriaturas());
console.log("CantidadCriaturas  " + CantidadCriaturas)

let observador = new IntersectionObserver((entradas, observador)=>{
    console.log("Entradas " +entradas.length);
    entradas.forEach(entrada=>{
        if(entrada.isIntersecting){
            console.log("Enrto por entrada")
            cargarCriaturas();
        }
    })},{
    rootMargin:'0px 0px 0px 0px',
    threshold:1.0
});



const cargarCriaturas = async() => {
    console.log("SCROLL  " + scroll)
    ContarCriaturas();
    

    
    let apiUrl = 'https://localhost:44373/Criatura/PostCriaturaXpagina/'+scroll;
	try {
		const respuesta = new XMLHttpRequest;
        respuesta.open('GET',apiUrl,true)
        respuesta.send();

        respuesta.onreadystatechange = function(){
            if (this.readyState== 4 && this.status ==200) {
                //console.log(this.responseText)
                let datos = JSON.parse(this.responseText);
                //console.log(datos)
                for (let e of datos){
                    Criaturas+=`${e.nombre}`;
                    //console.log(e.id)
                    Resultado.innerHTML+= `
                        <tr class="fila">
                                <td class=Nombre ><span>${e.nombre}</span></td>
                                <td><span>${e.dificultad}</span></td>
                                <td><span>${e.velocidad} Pies</span></td>
                                <td><span>${e.velocidadNado} Pies</span></td>
                                <td><span>${e.velocidadVuelo} Pies</span></td>
                                <td><span>${e.tamaño}</span></td>
                                <td><span>${e.tipo}</span></td>
                                <td><span>${e.alineamiento}</span></td>
                        </tr>
                    `
                }
                if (CantidadCriaturas > Criaturas.length) {
                    if (UltimaCriatura) {
                        observador.unobserve(UltimaCriatura);
                    }
                const CriaturaEnPantalla = document.querySelectorAll('.ContenedorTabla .Nombre');
                console.log("Criatura en pantalla:  " + CriaturaEnPantalla.length)
                UltimaCriatura = CriaturaEnPantalla[CriaturaEnPantalla.length -1];
                console.log("UltimaCriatura  " + UltimaCriatura)
                observador.observe(UltimaCriatura);
                }
                scroll++;
            }
            
        }
	} catch(error){
		console.log(error);
	}

}




cargarCriaturas();
