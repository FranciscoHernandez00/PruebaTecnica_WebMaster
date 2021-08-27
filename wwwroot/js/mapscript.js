var map;
// Initialize and add the map
var getlong = document.getElementById("longitude").value;
var getlat = document.getElementById("latitude").value;

function initMap() {
    // The location of Uluru
    var longitud = parseFloat(getlong);
    var latitud = parseFloat(getlat);
    const uluru = { lat: latitud, lng: longitud };

    // The map, centered at Uluru
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 8,
        center: new google.maps.LatLng(13.728969, -89.158447),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    // The marker, positioned at Uluru
    const marker = new google.maps.Marker({
        position: uluru,
        map: map,
    });

    marker.addListener("click", () => {
        map.setZoom(12);
        map.setCenter(marker.getPosition());
    });

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

