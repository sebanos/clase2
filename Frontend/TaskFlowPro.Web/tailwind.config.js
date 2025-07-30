/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './Pages/**/*.{razor,html,cshtml}',
    './Shared/**/*.{razor,html,cshtml}',
    './Features/**/*.{razor,html,cshtml}',
    './Components/**/*.{razor,html,cshtml}',
    './Data/**/*.{razor,html,cshtml}',
    './wwwroot/**/*.html'
  ],
  theme: {
    extend: {
      colors: {
        background: 'var(--background)',
        foreground: 'var(--foreground)',
        card: {
          DEFAULT: 'var(--card)',
          foreground: 'var(--card-foreground)',
        },
        popover: {
          DEFAULT: 'var(--popover)',
          foreground: 'var(--popover-foreground)',
        },
        primary: {
          DEFAULT: 'var(--primary)',
          foreground: 'var(--primary-foreground)',
        },
        secondary: {
          DEFAULT: 'var(--secondary)',
          foreground: 'var(--secondary-foreground)',
        },
        accent: {
          DEFAULT: 'var(--accent)',
          foreground: 'var(--accent-foreground)',
        },
        muted: {
          DEFAULT: 'var(--muted)',
          foreground: 'var(--muted-foreground)',
        },
        destructive: {
          DEFAULT: 'var(--destructive)',
          foreground: 'var(--destructive-foreground)',
        },
        border: 'var(--border)',
        input: 'var(--input)',
        ring: 'var(--ring)',
        'status-completed': {
          DEFAULT: 'var(--status-completed)',
          foreground: 'var(--status-completed-foreground)',
        },
        'status-pending': {
          DEFAULT: 'var(--status-pending)',
          foreground: 'var(--status-pending-foreground)',
        },
        'status-urgent': {
          DEFAULT: 'var(--status-urgent)',
          foreground: 'var(--status-urgent-foreground)',
        },
        chart: {
          1: 'var(--chart-1)',
          2: 'var(--chart-2)',
          3: 'var(--chart-3)',
          4: 'var(--chart-4)',
          5: 'var(--chart-5)',
        },
      },
      borderRadius: {
        lg: 'var(--radius)',
        md: 'calc(var(--radius) - 2px)',
        sm: 'calc(var(--radius) - 4px)',
      },
      fontFamily: {
        sans: ['Inter', 'ui-sans-serif', 'system-ui', '-apple-system', 'BlinkMacSystemFont', 'Segoe UI', 'Roboto', 'Helvetica Neue', 'Arial', 'Noto Sans', 'sans-serif'],
      },
      animation: {
        'fade-in-up': 'fadeInUp 0.3s ease-out',
        'scale-in': 'scaleIn 0.2s ease-out',
        'checkmark': 'checkmark 0.3s ease-out',
        'float': 'floatUpDown 3s ease-in-out infinite',
        'shimmer': 'shimmer 2s infinite',
        'breathe': 'breathe 2s ease-in-out infinite',
        'slide-in-left': 'slideInLeft 0.4s ease-out',
        'slide-in-right': 'slideInRight 0.4s ease-out',
        'glow': 'glow 2s ease-in-out infinite',
      },
    },
  },
  plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/typography'),
  ],
}
