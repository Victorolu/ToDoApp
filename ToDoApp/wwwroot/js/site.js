(function () {
    startListenerForUpdateOnCheckboxes();
})();

function startListenerForUpdateOnCheckboxes() {
    let inputElements = document.querySelectorAll('.form-check-input');
    inputElements.forEach((element) => {
        element.addEventListener('click', (e) => {
            //Updates database with changes in todo entry being active
            let element = e.target
            let tabContentDiv = document.getElementById(element.checked ? 'completed' : 'uncompleted');
            tabContentDiv.appendChild(element.parentNode);

            fetch('todo/update', {
                method: 'PATCH',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ id: parseInt(element.value), isActive: !element.checked })
            }).then((response) => {
                return response.json();
            }).then((data) => {
                if (data.success) {
                    alert('Entry has been updated successfully');
                } else {
                    tabContentDiv = document.getElementById(!element.checked ? 'completed' : 'uncompleted');
                    tabContentDiv.appendChild(element.parentNode);
                    element.checked = !element.checked;
                    alert('Entry could not be updated')
                }
            })
        })
    })
}

function createNewEntry() {
    const newInputElement = document.getElementById('new-entry');
    const newInput = newInputElement.value.trim();
    newInputElement.value = '';
    if (!newInput == '') {
        let newEntry = {
            entryText: newInput,
            isActive: true,
            expiresBy: null
        }

        fetch('todo/add', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newEntry)
        }).then((response) => {
            return response.json();
        }).then((data) => {
            if (data.success) {
                const newEntryDiv = document.createElement('div');
                newEntryDiv.className = 'form-check';
                const newEntryDivContent = `<input class="form-check-input" type="checkbox" name="${data.entryId}" id="entry-(${data.entryId})" value="${data.entryId}">
                          <label class="form-check-label" for="${data.entryId}">${newInput}</label>
                          <button class="btn btn-outline-danger delete-button" onclick="deleteEntry(${data.entryId})">Delete</button>`;
                newEntryDiv.innerHTML = newEntryDivContent;
                tabContentDiv = document.getElementById('uncompleted');
                tabContentDiv.appendChild(newEntryDiv);
                startListenerForUpdateOnCheckboxes();
                alert('Entry has been created successfully');
            } else {
                alert('Entry could not be created')
            }
        })
    }
}

function deleteEntry(id) {
    let element = document.getElementById(`entry-(${id})`);
    element.parentNode.style.display = 'none';

    fetch(`todo/deleteentry?id=${id}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    }).then((response) => {
        return response.json();
    }).then((data) => {
        if (data.success) {
            element.parentNode.remove();
            alert('Entry has been deleted successfully');
        } else {
            element.parentNode.style.display = 'block';
            alert('Entry could not be deleted')
        }
    })
}