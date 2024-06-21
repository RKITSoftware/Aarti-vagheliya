

// Function to fetch novel data from the API
async function fetchNovels() {
    try {
        let response = await fetch('/api/CLNovel/GetNovels');
        if (!response.ok) {
            throw new Error('Network response was not ok ' + response.statusText);
        }
        let novels = await response.json();
        displayNovels(novels);
    } catch (error) {
        console.error('There has been a problem with your fetch operation:', error);
    }
}

// Function to display novels on the web page
function displayNovels(novels) {
    const novelsContainer = document.getElementById('novels-container');
    novelsContainer.innerHTML = '';

    novels.forEach(novel => {
        let novelElement = document.createElement('div');
        novelElement.className = 'novel';

        let title = document.createElement('h2');
        title.textContent = novel.title;
        novelElement.appendChild(title);

        let author = document.createElement('p');
        author.textContent = 'Author: ' + novel.author;
        novelElement.appendChild(author);

        let description = document.createElement('p');
        description.textContent = novel.description;
        novelElement.appendChild(description);

        novelsContainer.appendChild(novelElement);
    });
}

// Function to add a new novel
async function addNovel(novel) {
    try {
        let response = await fetch('/api/CLNovel/AddNovel', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(novel)
        });
        if (!response.ok) {
            throw new Error('Network response was not ok ' + response.statusText);
        }
        let result = await response.json();
        console.log('Novel added:', result);
        fetchNovels(); // Refresh the novel list
    } catch (error) {
        console.error('There has been a problem with your fetch operation:', error);
    }
}

// Function to update an existing novel
async function updateNovel(novel) {
    try {
        let response = await fetch('/api/CLNovel/UpdateNovelData', {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(novel)
        });
        if (!response.ok) {
            throw new Error('Network response was not ok ' + response.statusText);
        }
        let result = await response.json();
        console.log('Novel updated:', result);
        fetchNovels(); // Refresh the novel list
    } catch (error) {
        console.error('There has been a problem with your fetch operation:', error);
    }
}

// Function to delete a novel
async function deleteNovel(novelId) {
    try {
        let response = await fetch(`/api/CLNovel/DeleteNovel?id=${novelId}`, {
            method: 'DELETE'
        });
        if (!response.ok) {
            throw new Error('Network response was not ok ' + response.statusText);
        }
        let result = await response.json();
        console.log('Novel deleted:', result);
        fetchNovels(); // Refresh the novel list
    } catch (error) {
        console.error('There has been a problem with your fetch operation:', error);
    }
}

// Call fetchNovels on page load to display the list of novels
window.onload = fetchNovels;
