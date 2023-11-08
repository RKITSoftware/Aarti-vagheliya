
$(document).ready(function () {
    const todoList = $('#todoList');
    const todoInput = $('#todoInput');
    const addTodo = $('#addTodo');

    // Load existing todos from pai calls when the page loads
    loadTodos();

    // Add a new todo when the "Add" button is clicked
    addTodo.click(function () {
        const task = todoInput.val();
        if (task) {
            addNewTodoToServer(task);
            todoInput.val(''); // Clear the input field
        }
    });

    // Handle Delete button click event  
    todoList.on('click', '.delete-todo', function () {
        const todoId = $(this).data('id');
        deleteTodoFromServer(todoId);
    });

    // Handle Edit button click event
    todoList.on('click', '.edit-todo', function () {
        const todoItem = $(this).parent();
        const todoId = todoItem.data('id');
        const currentTask = todoItem.find('.task-text').text();
        const newTask = prompt('Edit task:', currentTask);
        if (newTask) {
            updateTodoOnServer(todoId, newTask);
        }
    });

    // Handle completed/incompleted button 
    todoList.on('click', '.complete-todo', function () {
        const todoItem = $(this).parent();
        const todoId = todoItem.data('id');
        const isCompleted = todoItem.hasClass('completed');
        const newCompletionStatus = !isCompleted;
    
        $.ajax({
            url: 'https://jsonplaceholder.typicode.com/todos/' + todoId,
            type: 'PUT',
            data: { completed: newCompletionStatus },
            success: function () {
                if (newCompletionStatus) {
                    todoItem.addClass('completed');
                    todoItem.find('.task-text').addClass('text-success');
                    $(this).text('Mark Incomplete');
                } else {
                    todoItem.removeClass('completed');
                    todoItem.find('.task-text').removeClass('text-success');
                    $(this).text('Mark Complete');
                }
            }
        });
    });
    

    //Function to load todo list when page load 
    function loadTodos() {
        $.get('https://jsonplaceholder.typicode.com/todos', function (todos) {
            todos.forEach(function (todo) {
                appendTodoItem(todo);
            });
        });
    }


    //Function for add new todoitem to the list
    function addNewTodoToServer(task) {
        $.post('https://jsonplaceholder.typicode.com/todos', { title: task, userId: 1, completed: false }, function (newTodo) {
            appendTodoItem(newTodo);
        });
    }


    //Function for delete todoitem
    function deleteTodoFromServer(todoId) {
        $.ajax({
            url: 'https://jsonplaceholder.typicode.com/todos/' + todoId,
            type: 'DELETE',
            success: function () {
                $(`[data-id=${todoId}]`).remove();
            }
        });
    }


    //Function for edit existing todoitem
    function updateTodoOnServer(todoId, newTask) {
        $.ajax({
            url: 'https://jsonplaceholder.typicode.com/todos/' + todoId,
            type: 'PUT',
            data: { title: newTask },
            success: function (updatedTodo) {
                $(`[data-id=${todoId}] .task-text`).text(updatedTodo.title);
            },
            error: function (xhr, status, error) {
                if (xhr.status === 500) {
                    alert('An error occurred while updating the task. Please try again later.');
                } else {
                    console.error('Error:', error);
                }
            }
        });
    }


    //Create new <li> to add new todoItem
    function appendTodoItem(todo) {
        const todoItem = `
            <li class="list-group-item ${todo.completed ? 'completed' : ''}" data-id="${todo.id}">
                <span class="task-text ${todo.completed ? 'text-success' : ''}">${todo.title}</span>
                <button class="btn btn-danger btn-sm float-right delete-todo ml-2" data-id="${todo.id}">Delete</button>
                <button class="btn btn-warning btn-sm float-right edit-todo ml-2">Edit</button>
                <button class="btn btn-${todo.completed ? 'success' : 'secondary'} btn-sm float-right complete-todo">${todo.completed ? 'Completed' : 'Incomplete'}</button>
            </li>`;
        todoList.append(todoItem);
    }

    
});
