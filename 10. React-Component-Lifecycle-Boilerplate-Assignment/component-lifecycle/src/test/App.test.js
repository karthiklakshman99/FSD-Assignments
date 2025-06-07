import { render, screen } from '@testing-library/react';
import App from '../App';

test('renders Hi Guest text', () => {
  render(<App />);
  const linkElement = screen.getByText(/Hello Guest/i);
  expect(linkElement).toBeInTheDocument();
});
