export function initialize() {
    var latlng = new google.maps.LatLng(31.042314156430002, 31.351937370538913);
    var options = {
        zoom: 19
        , center: latlng,
        mapTypeId: google.maps.MapTypeId.Satelite
    };
    var map = new google.maps.Map(document.getElementById("map"), options);
    const marker = new google.maps.Marker({
        position: latlng,
        map: map,
    });
    const triangleCoords = [
       /* { lat: 25.774, lng: -80.19 },
        { lat: 18.466, lng: -66.118 },
        { lat: 32.321, lng: -64.757 },
        { lat: 25.774, lng: -80.19 },*/
        { lat: 31.042453037369768, lng: 31.35163876762436 },
        { lat: 31.042430056590867, lng: 31.352157104497348 },
        { lat: 31.042066887291682, lng: 31.35213025140469 },

        { lat: 31.042089597105598, lng: 31.351618610488618 },
        
        
    ];
    // Construct the polygon.
    const bermudaTriangle = new google.maps.Polygon({
        paths: triangleCoords,
        strokeColor: "#FF0000",
        strokeOpacity: 0.8,
        strokeWeight: 2,
        fillColor: "#FF0000",
        fillOpacity: 0.35,
    });

    bermudaTriangle.setMap(map);

}