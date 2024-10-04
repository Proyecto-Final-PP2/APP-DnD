let scroll = 0;
let Ataque = '';
let UltimaAtaque;
let Resultado= document.querySelector('#Resultado');
Resultado.innerHTML= '';
let CantidadAtaque =0;


function ContarAtaques() {
    let apiUrl = 'https://localhost:44373/Ataque/GetContarTotalAtaques';
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
                    CantidadAtaques =+  Number(e.max);
                    
                }
            }            
        }
	} catch(error){
		console.log(error);
	}
}


let observador = new IntersectionObserver((entradas, observador)=>{
    console.log("Entradas " +entradas.length);
    entradas.forEach(entrada=>{
        if(entrada.isIntersecting){
            console.log("Enrto por entrada")
            cargarAtaques();
        }
    })},{
    rootMargin:'0px 0px 0px 0px',
    threshold:1.0
});



const cargarAtaques = async() => {
    console.log("SCROLL  " + scroll)
    if (scroll ==0) {
        ContarAtaques();
    }
    console.log("CantidadAtaques  " + CantidadAtaques)
    let apiUrl = 'https://localhost:44373/Ataque/PostAtaqueXpagina/'+scroll;
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
                    Ataques+=`${e.nombre}`;
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
                const AtaqueEnPantalla = document.querySelectorAll('.ContenedorTabla .Nombre');
                if (CantidadAtaques > AtaqueEnPantalla.length || scroll ==0) {
                    if (UltimaAtaque) {
                        observador.unobserve(UltimaAtaque);
                    }
                
                console.log("Ataque en pantalla:  " + AtaqueEnPantalla.length)
                UltimaAtaque = AtaqueEnPantalla[AtaqueEnPantalla.length -1];
                console.log("UltimaAtaque  " + UltimaAtaque)
                observador.observe(UltimaAtaque);
                }
                scroll++;
            }
            
        }
	} catch(error){
		console.log(error);
	}

}




cargarAtaques();