const uri = 'api/Styles';
let styles = [];

function getStyles() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayStyles(data))
        .catch(error => console.error('Unable to get styles.', error));
}

function addStyle() {
    const addNameTextbox = document.getElementById('add-name');
   
    const style = {
        name: addNameTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(style)
    }).then(response => response.json())
        .then(() => {
            getStyles();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add style.', error));
}
function deleteStyle(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getStyles())
        .catch(error => console.error('Unable to delete style.', error));
}

function displayEditForm(id) {
    const style = styles.find(category => style.id === id);

    document.getElementById('edit-id').value = style.id;
    document.getElementById('edit-name').value = style.name;
    document.getElementById('editForm').style.display = 'block';
}

function updateStyle() {
    const styleId = document.getElementById('edit-id').value;
    const style = {
        id: parseInt(styleId, 10),
        name: document.getElementById('edit-name').value.trim()
        
    };

    fetch(`${uri}/${styleId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(style)
    })
        .then(() => getStyles())
        .catch(error => console.error('Unable to update style.', error));

    closeInput();

    return false;
}
function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayStyles(data) {
    const tBody = document.getElementById('styles');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(style => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Редагувати';
        editButton.setAttribute('onclick', `displayEditForm(${style.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Видалити';
        deleteButton.setAttribute('onclick', `deleteStyle(${style.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(style.name);
        td1.appendChild(textNode);

        let td3 = tr.insertCell(1);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(2);
        td4.appendChild(deleteButton);

    });

    styles = data;
}












