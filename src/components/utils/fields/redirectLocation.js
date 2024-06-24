import {stateCode} from '../../../helpers/stateCode'
export default function redirectLocation() {
    if ("geolocation" in navigator) {
        navigator.geolocation.getCurrentPosition(async function(position) {
            const lat = position.coords.latitude;
            const lon = position.coords.longitude;

            console.log(`Latitude: ${lat}, Longitude: ${lon}`);

            const region = await determineRegion(lat, lon);

            console.log(`Região determinada: ${region}`);

            

            if (stateCode[region]) {
                window.location.href = stateCode[region];
            } else {
                console.log('Região não mapeada:', region);
                alert('Localização não mapeada para redirecionamento.');
            }
        }, function(error) {
            console.error("Erro ao obter a localização:", error);
            alert('Erro ao obter a localização.');
        });
    } else {
        alert("Geolocalização não é suportada por este navegador.");
    }
}

async function determineRegion(lat, lon) {
    const apiKey = '5e8e772af8cb4984ae84428e885dae28';
    const url = `https://api.opencagedata.com/geocode/v1/json?q=${lat}+${lon}&key=${apiKey}`;

    try {
        const response = await fetch(url);
        const data = await response.json();

        console.log('Dados da API de geocodificação:', data);

        if (data.results && data.results.length > 0) {
            const components = data.results[0].components;
            let region = '';
            
            // Tenta pegar a combinação bairro-estado
            if (components.suburb && components.state_code) {
                region = `${components.suburb}-${components.state_code}`;
            }
            // Tenta pegar a combinação cidade-estado
            else if (components.city && components.state_code) {
                region = `${components.city}-${components.state_code}`;
            }
            // Se não encontrar suburb ou city, usa state
            else if (components.state && components.state_code) {
                region = `${components.state}-${components.state_code}`;
            }

            return region; // Retorna o nome da região (bairro, cidade ou estado)
        }
        return 'Desconhecido'; // Retorna desconhecido se não houver resultados ou região
    } catch (error) {
        console.error("Erro ao acessar a API de geocoding:", error);
        return 'Desconhecido'; // Retorna desconhecido em caso de erro
    }
}
