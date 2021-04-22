import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { AuthorDto } from '../authors/models';

export interface BookCreateDto {
  title?: string;
  year?: number;
  authorId?: string;
}

export interface BookDto extends FullAuditedEntityDto<string> {
  title?: string;
  year?: number;
  authorId?: string;
}

export interface BookUpdateDto {
  title?: string;
  year?: number;
  authorId?: string;
}

export interface BookWithNavigationPropertiesDto {
  book: BookDto;
  author: AuthorDto;
}

export interface GetBooksInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  title?: string;
  yearMin?: number;
  yearMax?: number;
  authorId?: string;
}
