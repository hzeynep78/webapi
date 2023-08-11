var map = new ol.Map({
    target: 'map',
    layers: [
        new ol.layer.Tile({
            source: new ol.source.OSM()
        })
    ],
    view: new ol.View({
        center: ol.proj.fromLonLat([30.707417, 36.890257]), // Türkiye'nin koordinatları
        zoom: 6 // Uygun bir zoom seviyesi (1 ile 19 arasında)
    })
});

var draw; // Çizim aracı

document.getElementById('addDoorBtn').addEventListener('click', function() {
    draw = new ol.interaction.Draw({
        source: new ol.source.Vector({
            features: new ol.Collection(),
        }),
        type: 'Point', // Çizim aracını Point (nokta) olarak değiştiriyoruz
    });

    map.addInteraction(draw);

    draw.on('drawend', function(event) {
        var feature = event.feature;
        var coordinates = feature.getGeometry().getCoordinates(); // Kapının koordinatları (tek bir nokta olacak)

        var modal = document.getElementById('modal');
        modal.style.display = 'block';

        document.getElementById('xInput').value = coordinates[0];
        document.getElementById('yInput').value = coordinates[1];
        document.getElementById('xInput').disabled = true; // X koordinatı alanını devre dışı bırakıyoruz
        document.getElementById('yInput').disabled = true; // Y koordinatı alanını devre dışı bırakıyoruz

        document.getElementById('saveBtn').addEventListener('click', function() {
            var x = coordinates[0];
            var y = coordinates[1];
            var name = document.getElementById('nameInput').value;

            // Verileri API'ye gönderme işlemi
            fetch('https://localhost:7030/api/UR', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ x, y, name }),
            })
            .then(response => response.json())
            .then(data => {
                // API'den dönen cevap burada işlenebilir
                var messageBox = document.getElementById('messageBox');
                messageBox.innerHTML = data.message;
                messageBox.style.display = 'block';

                setTimeout(function() {
                    messageBox.style.display = 'none';
                }, 3000);

                closeModal();
            })
            .catch(error => {
                // API isteği başarısız olursa burada hata işleme yapılabilir
                console.error('API Hatası:', error);
            });
        });

        document.getElementById('cancelBtn').addEventListener('click', function() {
            closeModal();
        });

        function closeModal() {
            map.removeInteraction(draw);
            modal.style.display = 'none';
        }
    });
});

document.getElementById('queryDoorBtn').addEventListener('click', function() {
    // Modal açılacak
    var modal = document.getElementById('modal');
    modal.style.display = 'block';

    // DataTable oluşturulacak
    var datatableContainer = document.getElementById('datatableContainer');
    datatableContainer.innerHTML = ''; // Önce içeriği temizleyelim (her tıklamada temizlemek için)

    fetch('https://localhost:7030/api/UR')
        .then(response => response.json())
        .then(data => {
            // API'den gelen verileri kullanarak DataTable oluşturulacak
            var table = document.createElement('table');
            var headerRow = table.insertRow();
            var headers = ['ID', 'X Koordinatı', 'Y Koordinatı', 'Kapı İsmi'];

            for (var i = 0; i < headers.length; i++) {
                var headerCell = headerRow.insertCell();
                headerCell.textContent = headers[i];
            }

            for (var i = 0; i < data.length; i++) {
                var row = table.insertRow();
                var idCell = row.insertCell();
                var xCell = row.insertCell();
                var yCell = row.insertCell();
                var nameCell = row.insertCell();

                idCell.textContent = data[i].id;
                xCell.textContent = data[i].x;
                yCell.textContent = data[i].y;
                nameCell.textContent = data[i].name;
            }

            datatableContainer.appendChild(table);
        })
        .catch(error => {
            console.error('API Hatası:', error);
        });
});
