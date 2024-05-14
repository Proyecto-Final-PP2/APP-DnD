let scroll = 1;
let Criaturas = '';
const apiUrl = 'https://localhost:44373/Criatura';
const cargarCriaturas = async() => {
	try {
		const respuesta = new XMLHttpRequest;
        respuesta.open('GET',apiUrl,true)
        respuesta.send();

        respuesta.onreadystatechange = function(){
            if (this.readyState== 4 && this.status ==200) {
                //console.log(this.responseText)
                let datos = JSON.parse(this.responseText);
                console.log(datos)

                let Resultado= document.querySelector('#Resultado');
                Resultado.innerHTML= '';
                for (let e of datos){
                    console.log(e.id)
                    Resultado.innerHTML+= `
                        <tr>
                                <td>${e.id}</td>
                                <td>${e.subID}</td>
                                <td>${e.Nombre}</td>
                        </tr>
                    `
                }
            }
            
        }
	} catch(error){
		console.log("LPM " +error );
	}

}

cargarCriaturas();