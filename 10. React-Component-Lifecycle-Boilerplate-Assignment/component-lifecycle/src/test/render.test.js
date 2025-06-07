import { render, screen } from '@testing-library/react';
import App from '../App';

test('renders Alpha text', () => {
  render(<App />);
  const linkElement = screen.getByText(/Contact Alpha/i);
  expect(linkElement).toBeInTheDocument();
});
