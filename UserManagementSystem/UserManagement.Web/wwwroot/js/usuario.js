// Variable global para controlar el modo de edición
let modoEdicion = false;
let modalUsuario;

// Inicializar modal al cargar la página
document.addEventListener('DOMContentLoaded', function() {
    modalUsuario = new bootstrap.Modal(document.getElementById('modalUsuario'));
});

// Abrir modal para nuevo usuario
function abrirModalNuevo() {
    modoEdicion = false;
    document.getElementById('modalTitulo').textContent = 'Nuevo Usuario';
    document.getElementById('formUsuario').reset();
    document.getElementById('formUsuario').classList.remove('was-validated');
    document.getElementById('usuarioId').value = '';
    document.getElementById('password').required = true;
    modalUsuario.show();
}

// Abrir modal para editar usuario
function abrirModalEditar(id) {
    modoEdicion = true;
    document.getElementById('modalTitulo').textContent = 'Editar Usuario';
    document.getElementById('formUsuario').classList.remove('was-validated');
    document.getElementById('password').required = false;
    
    // Obtener datos del usuario mediante AJAX
    fetch('/Usuario/Obtener/' + id)
        .then(response => response.json())
        .then(data => {
            document.getElementById('usuarioId').value = data.id;
            document.getElementById('nombreCompleto').value = data.nombreCompleto;
            document.getElementById('nombreUsuario').value = data.nombreUsuario;
            document.getElementById('correo').value = data.correo;
            document.getElementById('estatus').value = data.estatus.toString();
            document.getElementById('password').value = '';
            modalUsuario.show();
        })
        .catch(error => {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'No se pudo cargar la información del usuario'
            });
        });
}

// Guardar usuario (crear o actualizar)
function guardarUsuario() {
    const form = document.getElementById('formUsuario');
    
    // Validar formulario
    if (!form.checkValidity()) {
        form.classList.add('was-validated');
        return;
    }

    // Preparar datos
    const usuarioData = {
        id: parseInt(document.getElementById('usuarioId').value) || 0,
        nombreCompleto: document.getElementById('nombreCompleto').value,
        nombreUsuario: document.getElementById('nombreUsuario').value,
        password: document.getElementById('password').value,
        correo: document.getElementById('correo').value,
        estatus: document.getElementById('estatus').value === 'true'
    };

    // Determinar la URL
    const url = modoEdicion ? '/Usuario/Actualizar' : '/Usuario/Crear';

    // Mostrar loading
    Swal.fire({
        title: 'Guardando...',
        allowOutsideClick: false,
        didOpen: () => {
            Swal.showLoading();
        }
    });

    // Enviar petición AJAX
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(usuarioData)
    })
    .then(response => response.json())
    .then(data => {
        Swal.close();
        
        if (data.exito) {
            Swal.fire({
                icon: 'success',
                title: '¡Éxito!',
                text: data.mensaje,
                timer: 2000,
                showConfirmButton: false
            }).then(() => {
                modalUsuario.hide();
                location.reload();
            });
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: data.mensaje
            });
        }
    })
    .catch(error => {
        Swal.close();
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Ocurrió un error al guardar el usuario'
        });
    });
}

// Eliminar usuario
function eliminarUsuario(id) {
    Swal.fire({
        title: '¿Está seguro?',
        text: "Esta acción no se puede revertir",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Sí, eliminar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            fetch('/Usuario/Eliminar/' + id, {
                method: 'POST'
            })
            .then(response => response.json())
            .then(data => {
                if (data.exito) {
                    Swal.fire({
                        icon: 'success',
                        title: '¡Eliminado!',
                        text: data.mensaje,
                        timer: 2000,
                        showConfirmButton: false
                    }).then(() => {
                        location.reload();
                    });
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: data.mensaje
                    });
                }
            })
            .catch(error => {
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'No se pudo eliminar el usuario'
                });
            });
        }
    });
}

// Validación en tiempo real para la contraseña
document.addEventListener('DOMContentLoaded', function() {
    const passwordInput = document.getElementById('password');
    if (passwordInput) {
        passwordInput.addEventListener('input', function() {
            const password = this.value;
            const pattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{9,}$/;
            
            if (password.length > 0 && !pattern.test(password)) {
                this.classList.add('is-invalid');
                this.classList.remove('is-valid');
            } else if (password.length > 0) {
                this.classList.add('is-valid');
                this.classList.remove('is-invalid');
            } else {
                this.classList.remove('is-valid', 'is-invalid');
            }
        });
    }
});