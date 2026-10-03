import { ForbiddenName } from './forbidden-name';

describe('ForbiddenName', () => {
  it('should create an instance', () => {
    const directive = new ForbiddenName();
    expect(directive).toBeTruthy();
  });
});
