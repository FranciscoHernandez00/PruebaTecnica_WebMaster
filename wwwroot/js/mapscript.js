var map;
// Initialize and add the map


function initMap() {
    // The location of Uluru
    var longitud = -88.219131;
    var latitud = 13.482358;
    const uluru = { lat: latitud, lng: longitud };
    // The map, centered at Uluru
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 8,
        center: uluru,
    });
    // The marker, positioned at Uluru
    const marker = new google.maps.Marker({
        position: uluru,
        map: map,
    });

    map.addListener('click', () => {
        var hola = map.getCenter();
    })

    google.maps.event.addListener(map, 'click', function (event) {
        displayCoordinates(event.latLng);
        
    });

    function displayCoordinates(pnt) {

        var lat = pnt.lat();
        lat = lat.toFixed(6);
        var lng = pnt.lng();
        lng = lng.toFixed(6);
        document.getElementById("latitude").value = lat;
        document.getElementById("longitude").value = lng;
    }
}

