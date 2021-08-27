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

}