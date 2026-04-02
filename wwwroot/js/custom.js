// Animaciones al cargar la página
document.addEventListener('DOMContentLoaded', function() {
    // Agregar animación de entrada a las tarjetas
    const cards = document.querySelectorAll('.panel-card, .metric-card');
    cards.forEach((card, index) => {
        card.style.animation = `slideInUp 0.5s ease-out ${index * 0.1}s both`;
    });

    // Agregar efectos hover a los botones
    const buttons = document.querySelectorAll('.btn');
    buttons.forEach(button => {
        button.addEventListener('mouseenter', function() {
            this.classList.add('btn-ripple');
        });
    });

    // Animar números en las tarjetas de métricas
    animateCounters();

    // Efecto parallax en scroll
    window.addEventListener('scroll', function() {
        const parallaxElements = document.querySelectorAll('.parallax-card');
        parallaxElements.forEach(element => {
            const scrollPosition = window.scrollY;
            const elementPosition = element.offsetTop;
            const offset = scrollPosition - elementPosition + window.innerHeight;
            element.style.transform = `translateY(${offset * 0.1}px)`;
        });
    });
});

// Función para animar contadores de números
function animateCounters() {
    const counters = document.querySelectorAll('.metric-card h2');
    
    counters.forEach(counter => {
        const target = parseInt(counter.textContent);
        
        if (!isNaN(target)) {
            const increment = target / 50;
            let current = 0;
            
            const timer = setInterval(() => {
                current += increment;
                if (current >= target) {
                    counter.textContent = target.toLocaleString();
                    clearInterval(timer);
                } else {
                    counter.textContent = Math.floor(current).toLocaleString();
                }
            }, 30);
        }
    });
}

// Función para agregar feedback visual en clicks
document.addEventListener('click', function(event) {
    if (event.target.classList.contains('btn')) {
        createRipple(event);
    }
});

function createRipple(event) {
    const button = event.currentTarget;
    const circle = document.createElement('span');
    const diameter = Math.max(button.clientWidth, button.clientHeight);
    const radius = diameter / 2;
    
    circle.style.width = circle.style.height = diameter + 'px';
    circle.style.left = event.clientX - button.offsetLeft - radius + 'px';
    circle.style.top = event.clientY - button.offsetTop - radius + 'px';
    circle.classList.add('ripple');
    
    const ripple = button.querySelector('.ripple');
    if (ripple) {
        ripple.remove();
    }
    
    button.appendChild(circle);
}

// Validación mejorada de formularios
document.addEventListener('submit', function(event) {
    const form = event.target;
    
    if (form.classList.contains('needs-validation')) {
        if (!form.checkValidity()) {
            event.preventDefault();
            event.stopPropagation();
        }
        form.classList.add('was-validated');
    }
}, true);

// Función para búsqueda en tiempo real (opcional)
function setupRealtimeSearch(inputSelector, tableSelector) {
    const searchInput = document.querySelector(inputSelector);
    const table = document.querySelector(tableSelector);
    
    if (searchInput && table) {
        searchInput.addEventListener('keyup', function() {
            const searchTerm = this.value.toLowerCase();
            const rows = table.querySelectorAll('tbody tr');
            
            rows.forEach(row => {
                const text = row.textContent.toLowerCase();
                row.style.display = text.includes(searchTerm) ? '' : 'none';
            });
        });
    }
}

// Función para mostrar notificaciones tipo toast
function showNotification(message, type = 'info') {
    const container = document.getElementById('notification-container') || createNotificationContainer();
    
    const toast = document.createElement('div');
    toast.className = `alert alert-${type} alert-dismissible fade show slide-in-up`;
    toast.setAttribute('role', 'alert');
    toast.innerHTML = `
        ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    `;
    
    container.appendChild(toast);
    
    // Auto-cerrar después de 5 segundos
    setTimeout(() => {
        toast.remove();
    }, 5000);
}

function createNotificationContainer() {
    const container = document.createElement('div');
    container.id = 'notification-container';
    container.style.position = 'fixed';
    container.style.top = '20px';
    container.style.right = '20px';
    container.style.zIndex = '9999';
    container.style.maxWidth = '500px';
    document.body.appendChild(container);
    return container;
}

// Función para agregar tooltips de Bootstrap
function initializeTooltips() {
    const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    tooltipTriggerList.map(function(tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
}

// Llamar a la función de tooltips cuando el DOM está listo
document.addEventListener('DOMContentLoaded', initializeTooltips);

// Función para suavizar el scroll
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({
                behavior: 'smooth',
                block: 'start'
            });
        }
    });
});

// Detectar si el usuario está en el tope de la página
window.addEventListener('scroll', function() {
    const nav = document.querySelector('nav');
    if (window.scrollY > 50) {
        nav.style.boxShadow = '0 8px 32px rgba(0, 0, 0, 0.2)';
    } else {
        nav.style.boxShadow = '0 8px 32px rgba(0, 0, 0, 0.15)';
    }
});

// Agregar efecto de carga
window.addEventListener('load', function() {
    document.body.classList.add('loaded');
});
